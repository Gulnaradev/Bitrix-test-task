using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.CRM
{
    public class CrmDealDetails
    {
        public IWebDriver Driver { get; }
        private readonly WebItem dealDetailsForm = new WebItem(
            "//div[contains(@data-cid,'main')]",
            "Детали сделки"
        );

        public CrmDealDetails(IWebDriver driver = default)
        {
            Driver = driver;
        }

        public void WaitUntilOpened(int maxWait)
        {
            dealDetailsForm.WaitElementDisplayed(maxWait, Driver);
        }
    }
}

