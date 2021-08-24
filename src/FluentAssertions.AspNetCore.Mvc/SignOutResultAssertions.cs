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
    /// Contains a number of methods to assert that a <see cref="SignOutResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class SignOutResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignOutResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public SignOutResultAssertions(object subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The authentication properties on the SignOutResult.
        /// </summary>
        public AuthenticationProperties AuthenticationProperties => SignOutResultSubject.Properties;

        /// <summary>
        ///     The items value in the authentication properties on the SignOutResult.
        /// </summary>
        public IDictionary<string, string> Items => SignOutResultSubject.Properties?.Items;

        /// <summary>
        ///     The is persistent value in the authentication properties on the SignOutResult.
        /// </summary>
        public bool IsPersistent => SignOutResultSubject.Properties?.IsPersistent ?? false;

        /// <summary>
        ///     The redirect uri value in the authentication properties on the SignOutResult.
        /// </summary>
        public string RedirectUri => SignOutResultSubject.Properties?.RedirectUri;

        /// <summary>
        ///     The issued utc value in the authentication properties on the SignOutResult.
        /// </summary>
        public DateTimeOffset? IssuedUtc => SignOutResultSubject.Properties?.IssuedUtc;

        /// <summary>
        ///     The expires utc value in the authentication properties on the SignOutResult.
        /// </summary>
        public DateTimeOffset? ExpiresUtc => SignOutResultSubject.Properties?.ExpiresUtc;

        /// <summary>
        ///     The allow refresh value in the authentication properties on the SignOutResult.
        /// </summary>
        public bool? AllowRefresh => SignOutResultSubject.Properties?.AllowRefresh;

        /// <summary>
        ///     The authentication schemes value on the SignOutResult.
        /// </summary>
        public IList<string> AuthenticationSchemes => SignOutResultSubject.AuthenticationSchemes;
        #endregion

        #region Private Properties

        private SignOutResult SignOutResultSubject => (SignOutResult)Subject;

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
        public SignOutResultAssertions WithAuthenticationProperties(AuthenticationProperties expectedAuthenticationProperties, string reason = "", params object[] reasonArgs)
        {
            var actualAuthenticationProperties = AuthenticationProperties;

            Execute.Assertion
                .ForCondition(actualAuthenticationProperties == expectedAuthenticationProperties)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignOutResult.AuthenticationProperties")
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
        public SignOutResultAssertions WithIsPersistent(bool expectedIsPersistent, string reason = "", params object[] reasonArgs)
        {
            var actualIsPersistent = IsPersistent;

            Execute.Assertion
                .ForCondition(actualIsPersistent == expectedIsPersistent)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignOutResult.AuthenticationProperties.IsPersistent")
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
        public SignOutResultAssertions WithRedirectUri(string expectedRedirectUri, string reason = "", params object[] reasonArgs)
        {
            var actualRedirectUri = RedirectUri;

            Execute.Assertion
                .ForCondition(string.Equals(actualRedirectUri, expectedRedirectUri))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignOutResult.AuthenticationProperties.RedirectUri")
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
        public SignOutResultAssertions WithIssuedUtc(DateTimeOffset? expectedIssuedUtc, string reason = "", params object[] reasonArgs)
        {
            var actualResult = IssuedUtc;
            DateTimeOffset? expectedResult = AssertionHelpers.RoundToSeconds(expectedIssuedUtc);

            Execute.Assertion
                .ForCondition(expectedResult == actualResult)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignOutResult.AuthenticationProperties.IssuedUtc")
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
        public SignOutResultAssertions WithExpiresUtc(DateTimeOffset? expectedExpiresUtc, string reason = "", params object[] reasonArgs)
        {
            var actualResult = ExpiresUtc;

            DateTimeOffset? expectedResult = AssertionHelpers.RoundToSeconds(expectedExpiresUtc);

            Execute.Assertion
                .ForCondition(expectedResult == actualResult)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignOutResult.AuthenticationProperties.ExpiresUtc")
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
        public SignOutResultAssertions WithAllowRefresh(bool? expectedAllowRefresh, string reason = "", params object[] reasonArgs)
        {
            var actualAllowRefresh = AllowRefresh;

            Execute.Assertion
                .ForCondition(actualAllowRefresh == expectedAllowRefresh)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("SignOutResult.AuthenticationProperties.AllowRefresh")
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
        public SignOutResultAssertions ContainsItem(string expectedKey, string expectedValue, string reason = "", params object[] reasonArgs)
        {
            var actualItems = Items;

            AssertionHelpers.AssertStringObjectDictionary(actualItems, "SignOutResult.AuthenticationProperties.Items",
                expectedKey, expectedValue, reason, reasonArgs);

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
        public SignOutResultAssertions WithAuthenticationSchemes(IList<string> expectedAuthenticationSchemes, string reason = "", params object[] reasonArgs)
        {
            var actualAuthenticationSchemes = AuthenticationSchemes;

            var difference1 = actualAuthenticationSchemes.Except(expectedAuthenticationSchemes);
            var difference2 = expectedAuthenticationSchemes.Except(actualAuthenticationSchemes);

            Execute.Assertion
                .ForCondition(!difference1.Any() && !difference2.Any())
                .BecauseOf(reason, reasonArgs)
                .FailWith(string.Format(FailureMessages.CommonListsNotIdentical, "SignOutResult.AuthenticationSchemes"));

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
        public SignOutResultAssertions ContainsScheme(string expectedScheme, string reason = "", params object[] reasonArgs)
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
