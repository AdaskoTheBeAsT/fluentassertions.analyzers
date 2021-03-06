﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace FluentAssertions.Analyzers
{

    public abstract class FluentAssertionsCodeFixProvider : CodeFixProvider
    {
        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            foreach (var diagnostic in context.Diagnostics)
            {
                var expression = (ExpressionSyntax)root.FindNode(diagnostic.Location.SourceSpan);
                if (CanRewriteAssertion(expression))
                {
                    context.RegisterCodeFix(CodeAction.Create(
                        title: diagnostic.Properties[Constants.DiagnosticProperties.Title],
                        createChangedDocument: c => RewriteAssertion(context.Document, expression, diagnostic.Properties, c)
                        ), diagnostic);
                }
            }
        }

        protected virtual bool CanRewriteAssertion(ExpressionSyntax expression) => true;

        protected async Task<Document> RewriteAssertion(Document document, ExpressionSyntax expression, ImmutableDictionary<string, string> properties, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            var newExpression = GetNewExpression(expression, new FluentAssertionsDiagnosticProperties(properties));
            
            root = root.ReplaceNode(expression, newExpression);

            return document.WithSyntaxRoot(root);
        }

        protected abstract ExpressionSyntax GetNewExpression(ExpressionSyntax expression, FluentAssertionsDiagnosticProperties properties);

        protected ExpressionSyntax GetNewExpression(ExpressionSyntax expression, params NodeReplacement[] replacements)
        {
            var newStatement = expression;
            foreach (var replacement in replacements)
            {
                newStatement = GetNewExpression(newStatement, replacement);
                var code = newStatement.ToFullString();
            }
            return newStatement;
        }

        protected ExpressionSyntax GetNewExpression(ExpressionSyntax expression, NodeReplacement replacement)
        {
            var visitor = new MemberAccessExpressionsCSharpSyntaxVisitor();
            expression.Accept(visitor);
            var members = new LinkedList<MemberAccessExpressionSyntax>(visitor.Members);

            var current = members.Last;
            while (current != null)
            {
                if (replacement.IsValidNode(current.Value))
                {
                    // extract custom data into the replacement object
                    replacement.ExtractValues(current.Value);

                    return expression.ReplaceNode(replacement.ComputeOld(current), replacement.ComputeNew(current));
                }
                current = current.Previous;
            }

            throw new System.InvalidOperationException("should not get here");
        }
    }
}
