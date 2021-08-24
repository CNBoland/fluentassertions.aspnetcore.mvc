﻿using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="ChallengeResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ChallengeResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ChallengeResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public ChallengeResultAssertions(object subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// The <see cref="ChallengeResult.Properties"/> that belongs to the ChallengeResult.
        /// </summary>
        public AuthenticationProperties AuthenticationProperties => ChallengeResultSubject.Properties;

        /// <summary>
        /// The <see cref="AuthenticationProperties.Items"/> that belongs to the ChallengeResult.
        /// </summary>
        public IDictionary<string, string> Items => ChallengeResultSubject.Properties?.Items;

        /// <summary>
        /// The <see cref="AuthenticationProperties.IsPersistent"/> that belongs to the ChallengeResult.
        /// </summary>
        public bool IsPersistent => ChallengeResultSubject.Properties?.IsPersistent ?? false;

        /// <summary>
        /// The <see cref="AuthenticationProperties.RedirectUri"/> that belongs to the ChallengeResult.
        /// </summary>
        public string RedirectUri => ChallengeResultSubject.Properties?.RedirectUri;

        /// <summary>
        /// The <see cref="AuthenticationProperties.IssuedUtc"/> that belongs to the ChallengeResult.
        /// </summary>
        public DateTimeOffset? IssuedUtc => ChallengeResultSubject.Properties?.IssuedUtc;

        /// <summary>
        /// The <see cref="AuthenticationProperties.ExpiresUtc"/> that belongs to the ChallengeResult.
        /// </summary>
        public DateTimeOffset? ExpiresUtc => ChallengeResultSubject.Properties?.ExpiresUtc;

        /// <summary>
        /// The <see cref="AuthenticationProperties.AllowRefresh"/> that belongs to the ChallengeResult.
        /// </summary>
        public bool? AllowRefresh => ChallengeResultSubject.Properties?.AllowRefresh;

        /// <summary>
        /// The <see cref="ChallengeResult.AuthenticationSchemes"/> that belongs to the ChallengeResult.
        /// </summary>
        public IList<string> AuthenticationSchemes => ChallengeResultSubject.AuthenticationSchemes;
        #endregion

        #region Private Properties

        private ChallengeResult ChallengeResultSubject => (ChallengeResult)Subject;

        #endregion

        #region Public Methods

        /// <summary>
        /// Asserts that the AuthenticationProperties is exactly the same as the expected AuthenticationProperties.
        /// </summary>
        /// <param name="expectedAuthenticationProperties">The expected AuthenticationProperties.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithAuthenticationProperties(AuthenticationProperties expectedAuthenticationProperties, string reason = "", params object[] reasonArgs)
        {
            var actualAuthenticationProperties = AuthenticationProperties;

            Execute.Assertion
                .ForCondition(actualAuthenticationProperties == expectedAuthenticationProperties)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("ChallengeResult.AuthenticationProperties")
                .FailWith(FailureMessages.CommonFailMessage, expectedAuthenticationProperties, actualAuthenticationProperties);

            return this;
        }

        /// <summary>
        /// Asserts that the IsPersistent is exactly the same as the expected IsPersistent.
        /// </summary>
        /// <param name="expectedIsPersistent">The expected IsPersistent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithIsPersistent(bool expectedIsPersistent, string reason = "", params object[] reasonArgs)
        {
            var actualIsPersistent = IsPersistent;

            Execute.Assertion
                .ForCondition(actualIsPersistent == expectedIsPersistent)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("ChallengeResult.AuthenticationProperties.IsPersistent")
                .FailWith(FailureMessages.CommonFailMessage, expectedIsPersistent, actualIsPersistent);

            return this;
        }

        /// <summary>
        /// Asserts that the RedirectUri is exactly the same as the expected RedirectUri.
        /// </summary>
        /// <param name="expectedRedirectUri">The expected RedirectUri.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithRedirectUri(string expectedRedirectUri, string reason = "", params object[] reasonArgs)
        {
            var actualRedirectUri = RedirectUri;

            Execute.Assertion
                .ForCondition(string.Equals(actualRedirectUri, expectedRedirectUri))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("ChallengeResult.AuthenticationProperties.RedirectUri")
                .FailWith(FailureMessages.CommonFailMessage, expectedRedirectUri, actualRedirectUri);

            return this;
        }

        /// <summary>
        /// Asserts that the IssuedUtc is exactly the same as the expected IssuedUtc.
        /// </summary>
        /// <param name="expectedIssuedUtc">The expected IssuedUtc.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithIssuedUtc(DateTimeOffset? expectedIssuedUtc, string reason = "", params object[] reasonArgs)
        {
            var actualResult = IssuedUtc;

            var expectedResult = AssertionHelpers.RoundToSeconds(expectedIssuedUtc);

            Execute.Assertion
                .ForCondition(expectedResult == actualResult)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("ChallengeResult.AuthenticationProperties.IssuedUtc")
                .FailWith(FailureMessages.CommonFailMessage, expectedResult, actualResult);

            return this;
        }

        /// <summary>
        /// Asserts that the ExpiresUtc is exactly the same as the expected ExpiresUtc.
        /// </summary>
        /// <param name="expectedExpiresUtc">The expected ExpiresUtc.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithExpiresUtc(DateTimeOffset? expectedExpiresUtc, string reason = "", params object[] reasonArgs)
        {
            var actualResult = ExpiresUtc;

            var expectedResult = AssertionHelpers.RoundToSeconds(expectedExpiresUtc);

            Execute.Assertion
                .ForCondition(expectedResult == actualResult)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("ChallengeResult.AuthenticationProperties.ExpiresUtc")
                .FailWith(FailureMessages.CommonFailMessage, expectedResult, actualResult);

            return this;
        }


        /// <summary>
        /// Asserts that the AllowRefresh is exactly the same as the expected AllowRefresh.
        /// </summary>
        /// <param name="expectedAllowRefresh">The expected AllowRefresh.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithAllowRefresh(bool? expectedAllowRefresh, string reason = "", params object[] reasonArgs)
        {
            var actualAllowRefresh = AllowRefresh;

            Execute.Assertion
                .ForCondition(actualAllowRefresh == expectedAllowRefresh)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("ChallengeResult.AuthenticationProperties.AllowRefresh")
                .FailWith(FailureMessages.CommonFailMessage, expectedAllowRefresh, actualAllowRefresh);

            return this;
        }

        /// <summary>
        /// Asserts that the Items contain the the expected Key Value Pair.
        /// </summary>
        /// <param name="expectedKey">The expected Key in Items.</param>
        /// <param name="expectedValue">The expected Value in Items.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions ContainsItem(string expectedKey, string expectedValue, string reason = "", params object[] reasonArgs)
        {
            var actualItems = Items;

            AssertionHelpers.AssertStringObjectDictionary(actualItems, "ChallengeResult.AuthenticationProperties.Items", expectedKey, expectedValue, reason, reasonArgs);

            return this;
        }

        /// <summary>
        /// Asserts that the AuthenticationSchemes is exactly the same as the expected AuthenticationSchemes.
        /// </summary>
        /// <param name="expectedAuthenticationSchemes">The expected AuthenticationSchemes.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions WithAuthenticationSchemes(IList<string> expectedAuthenticationSchemes, string reason = "", params object[] reasonArgs)
        {
            var actualAuthenticationSchemes = AuthenticationSchemes;

            var difference1 = actualAuthenticationSchemes.Except(expectedAuthenticationSchemes);
            var difference2 = expectedAuthenticationSchemes.Except(actualAuthenticationSchemes);

            Execute.Assertion
                .ForCondition(!difference1.Any() && !difference2.Any())
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonListsNotIdentical, "ChallengeResult.AuthenticationSchemes"));

            return this;
        }

        /// <summary>
        /// Asserts that the Authentication Schemes contain the the expected scheme.
        /// </summary>
        /// <param name="expectedScheme">The expected scheme.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public ChallengeResultAssertions ContainsScheme(string expectedScheme, string reason = "", params object[] reasonArgs)
        {
            var actualSchemes = AuthenticationSchemes;

            Execute.Assertion
                .ForCondition(actualSchemes.Contains(expectedScheme))
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonAuthenticationSchemesContainScheme, expectedScheme));

            return this;
        }

        #endregion
    }
}
