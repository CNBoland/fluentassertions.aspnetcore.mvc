﻿using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that a <see cref="LocalRedirectResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class LocalRedirectResultAssertions : ObjectAssertions
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocalRedirectResultAssertions" /> class.
        /// </summary>
        /// <param name="subject">The object to test assertion on</param>
        public LocalRedirectResultAssertions(LocalRedirectResult subject) : base(subject)
        {
        }

        #endregion

        #region Public Properties
        /// <summary>
        ///     The value on the LocalRedirectObjectResult
        /// </summary>
        public string Url => LocalRedirectResultSubject.Url;
        #endregion

        #region Private Properties
        private LocalRedirectResult LocalRedirectResultSubject => (LocalRedirectResult)Subject;

        #endregion

        #region Public Methods
        /// <summary>
        /// Asserts that the LocalUrls is exactly the same as the expected LocalUrl.
        /// </summary>
        /// <param name="expectedLocalUrl">The expected LocalUrl.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public LocalRedirectResultAssertions WithLocalUrl(string expectedLocalUrl, string reason = "", params object[] reasonArgs)
        {
            var actualLocalUrl = Url;

            Execute.Assertion
                .ForCondition(string.Equals(actualLocalUrl, expectedLocalUrl))
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("LocalRedirectResult.LocalUrl")
                .FailWith(FailureMessages.CommonFailMessage, expectedLocalUrl, actualLocalUrl);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect is permanent.
        /// </summary>
        /// <param name="expectedPermanent">Should the expected redirect be permanent.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public LocalRedirectResultAssertions WithPermanent(bool expectedPermanent, string reason = "", params object[] reasonArgs)
        {
            bool actualPermanent = LocalRedirectResultSubject.Permanent;

            Execute.Assertion
                .ForCondition(expectedPermanent == actualPermanent)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("LocalRedirectResult.Permanent")
                .FailWith(FailureMessages.CommonFailMessage, expectedPermanent, actualPermanent);

            return this;
        }

        /// <summary>
        /// Asserts that the redirect is PreserveMethod.
        /// </summary>
        /// <param name="expectedPreserveMethod">Should the expected redirect be PreserveMethod.</param>
        /// <param name="reason">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <paramref name="reason"/>.
        /// </param>
        public LocalRedirectResultAssertions WithPreserveMethod(bool expectedPreserveMethod, string reason = "", params object[] reasonArgs)
        {
            bool actualPreserveMethod = LocalRedirectResultSubject.PreserveMethod;

            Execute.Assertion
                .ForCondition(expectedPreserveMethod == actualPreserveMethod)
                .BecauseOf(reason, reasonArgs)
                .WithDefaultIdentifier("LocalRedirectResult.PreserveMethod")
                .FailWith(FailureMessages.CommonFailMessage, expectedPreserveMethod, actualPreserveMethod);

            return this;
        }

        #endregion
    }
}
