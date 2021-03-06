﻿using System;
using Feather.Widgets.TestUI.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.Sitefinity.TestUI.Framework.Framework.Wrappers.Backend.PageTemplates;
using Telerik.Sitefinity.TestUI.Framework.Wrappers.Backend.PageEditor;

namespace FeatherWidgets.TestUI.TestCases.Forms.MultiPageForms
{
    /// <summary>
    /// VerifyHeaderAndFooter test class.
    /// </summary>
    [TestClass]
    public class VerifyHeaderAndFooter_ : FeatherTestCase
    {
        /// <summary>
        /// UI test VerifyHeaderAndFooter
        /// </summary>
        [TestMethod,
        Owner(FeatherTeams.SitefinityTeam6),
        TestCategory(FeatherTestCategories.Bootstrap)]
        public void VerifyHeaderAndFooter()
        {
            BAT.Macros().NavigateTo().Modules().Forms(this.Culture);
            BAT.Wrappers().Backend().Forms().FormsDashboard().OpenFormFromTheGrid(FormName);
            BATFeather.Wrappers().Backend().Forms().FormsContentScreenWrapper().AddField(ContentBlock, Header);
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().EditWidget(ContentBlock);
            BATFeather.Wrappers().Backend().ContentBlocks().ContentBlocksWrapper().FillContentToContentBlockWidget(Header);
            BATFeather.Wrappers().Backend().ContentBlocks().ContentBlocksWrapper().SaveChanges();
            BATFeather.Wrappers().Backend().Forms().FormsContentScreenWrapper().AddField(ContentBlock, Footer);
            ActiveBrowser.WaitUntilReady();
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().EditWidget(ContentBlock, 1);
            BATFeather.Wrappers().Backend().ContentBlocks().ContentBlocksWrapper().FillContentToContentBlockWidget(Footer);
            BATFeather.Wrappers().Backend().ContentBlocks().ContentBlocksWrapper().SaveChanges();
            BAT.Wrappers().Backend().Forms().FormsContentScreen().PublishForm();

            BAT.Macros().NavigateTo().CustomPage("~/" + PageName.ToLower(), true, this.Culture);
            BATFeather.Wrappers().Frontend().Forms().FormsWrapper().VerifyContentBlockFieldTextIsVisible(Header);
            BATFeather.Wrappers().Frontend().Forms().FormsWrapper().VerifyContentBlockFieldTextIsVisible(Footer);
            BATFeather.Wrappers().Frontend().Forms().FormsWrapper().ClickNextButton();
            BATFeather.Wrappers().Frontend().Forms().FormsWrapper().VerifyContentBlockFieldTextIsVisible(Header);
            BATFeather.Wrappers().Frontend().Forms().FormsWrapper().VerifyContentBlockFieldTextIsVisible(Footer);
        }

        /// <summary>
        /// Performs Server Setup and prepare the system with needed data.
        /// </summary>
        protected override void ServerSetup()
        {
            BAT.Macros().User().EnsureAdminLoggedIn();
            BAT.Arrange(this.TestName).ExecuteSetUp();
        }

        /// <summary>
        /// Performs clean up and clears all data created by the test.
        /// </summary>
        protected override void ServerCleanup()
        {
            BAT.Arrange(this.TestName).ExecuteTearDown();
        }

        private const string FormName = "MultiPageForm";
        private const string PageBreak = "Page break";
        private const string ContentBlock = "Content block";
        private const string Footer = "Footer";
        private const string Header = "Header";
        private const string PageName = "FormPage";
    }
}
