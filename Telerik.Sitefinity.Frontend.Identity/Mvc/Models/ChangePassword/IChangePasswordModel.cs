﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Sitefinity.Frontend.Identity.Mvc.Models.ChangePassword
{
    /// <summary>
    /// This interface is used as a model for the <see cref="ChangePasswordController"/>.
    /// </summary>
    public interface IChangePasswordModel
    {
        /// <summary>
        /// Gets or sets the membership provider.
        /// </summary>
        /// <value>
        /// The membership provider.
        /// </value>
        string MembershipProvider { get; set; }

        /// <summary>
        /// Gets or sets the css class.
        /// </summary>
        /// <value>
        /// The css class.
        /// </value>
        string CssClass { get; set; }

        /// <summary>
        /// Gets or sets the change password page identifier.
        /// </summary>
        /// <value>
        /// The change password page identifier.
        /// </value>
        Guid? ChangePasswordRedirectPageId { get; set; }
        
        /// <summary>
        /// Gets or sets the change password complete action.
        /// </summary>
        /// <value>
        /// The change password complete action.
        /// </value>
        ChangePasswordCompleteAction ChangePasswordCompleteAction { get; set; }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="ChangePasswordViewModel"/>
        /// </returns>
        ChangePasswordViewModel GetViewModel();

        /// <summary>
        /// Gets the page URL.
        /// </summary>
        /// <param name="pageId">The page identifier.</param>
        /// <returns>
        /// The page url as string.
        /// </returns>
        string GetPageUrl(Guid? pageId);
    }
}
