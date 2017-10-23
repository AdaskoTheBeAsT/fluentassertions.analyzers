﻿namespace FluentAssertions.Analyzers
{
    public static class Constants
    {
        public static class DiagnosticProperties
        {
            public const string Title = nameof(Title);
            public const string VariableName = nameof(VariableName);
            public const string LambdaString = nameof(LambdaString);
            public const string ExpectedItemString = nameof(ExpectedItemString);
            public const string UnexpectedItemString = nameof(UnexpectedItemString);
            public const string BecauseArgumentsString = nameof(BecauseArgumentsString);
            public const string ArgumentString = nameof(ArgumentString);

            public const string VisitorName = nameof(VisitorName);
        }

        public static class Tips
        {
            public const string Category = "FluentAssertionTips";
            public static class Collections
            {
                public const string CollectionsShouldBeEmpty = nameof(CollectionsShouldBeEmpty);
                public const string CollectionsShouldNotBeEmpty = nameof(CollectionsShouldNotBeEmpty);
                public const string CollectionShouldContainProperty = nameof(CollectionShouldContainProperty);
                public const string CollectionShouldNotContainProperty = nameof(CollectionShouldNotContainProperty);
                public const string CollectionShouldContainItem = nameof(CollectionShouldContainItem);
                public const string CollectionShouldNotContainItem = nameof(CollectionShouldNotContainItem);
                public const string CollectionShouldHaveCount = nameof(CollectionShouldHaveCount);
                public const string CollectionShouldHaveCountGreaterThan = nameof(CollectionShouldHaveCountGreaterThan);
                public const string CollectionShouldHaveCountGreaterOrEqualTo = nameof(CollectionShouldHaveCountGreaterOrEqualTo);
                public const string CollectionShouldHaveCountLessThan = nameof(CollectionShouldHaveCountLessThan);
                public const string CollectionShouldHaveCountLessOrEqualTo = nameof(CollectionShouldHaveCountLessOrEqualTo);
                public const string CollectionShouldNotHaveCount = nameof(CollectionShouldNotHaveCount);
                public const string CollectionShouldContainSingle = nameof(CollectionShouldContainSingle);
                public const string CollectionShouldOnlyContainProperty = nameof(CollectionShouldOnlyContainProperty);
                public const string CollectionShouldHaveSameCount = nameof(CollectionShouldHaveSameCount);
                public const string CollectionShouldNotHaveSameCount = nameof(CollectionShouldNotHaveSameCount);
                public const string CollectionShouldContainSingleProperty = nameof(CollectionShouldContainSingleProperty);
                public const string CollectionShouldNotBeNullOrEmpty = nameof(CollectionShouldNotBeNullOrEmpty);
                public const string CollectionShouldHaveElementAt = nameof(CollectionShouldHaveElementAt);
                public const string CollectionShouldBeInAscendingOrder = nameof(CollectionShouldBeInAscendingOrder);
                public const string CollectionShouldBeInDescendingOrder = nameof(CollectionShouldBeInDescendingOrder);
                public const string CollectionShouldEqualOtherCollectionByComparer = nameof(CollectionShouldEqualOtherCollectionByComparer);
                public const string CollectionShouldNotIntersectWith = nameof(CollectionShouldNotIntersectWith);
                public const string CollectionShouldIntersectWith = nameof(CollectionShouldIntersectWith);
                public const string CollectionShouldNotContainNulls = nameof(CollectionShouldNotContainNulls);
                public const string CollectionShouldOnlyHaveUniqueItems = nameof(CollectionShouldOnlyHaveUniqueItems);
                public const string CollectionShouldOnlyHaveUniqueItemsByComparer = nameof(CollectionShouldOnlyHaveUniqueItemsByComparer);
                public const string CollectionShouldHaveElementAt0Null = nameof(CollectionShouldHaveElementAt0Null);
            }
            public static class Dictionaries
            {
                public const string DictionaryShouldContainKey = nameof(DictionaryShouldContainKey);
                public const string DictionaryShouldContainValue = nameof(DictionaryShouldContainValue);
                public const string DictionaryShouldContainKeyAndValue = nameof(DictionaryShouldContainKeyAndValue);
                public const string DictionaryShouldContainPair = nameof(DictionaryShouldContainPair);
                public const string DictionaryShouldNotContainKey = nameof(DictionaryShouldNotContainKey);
                public const string DictionaryShouldNotContainValue = nameof(DictionaryShouldNotContainValue);

            }
        }
    }
}