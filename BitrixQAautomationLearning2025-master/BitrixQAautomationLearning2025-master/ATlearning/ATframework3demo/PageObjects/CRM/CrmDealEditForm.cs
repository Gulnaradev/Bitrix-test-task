using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;

namespace ATframework3demo.PageObjects.CRM
{
    public class CrmDealEditForm
    {
        public IWebDriver Driver { get; }

        public CrmDealEditForm(IWebDriver driver = default)
        {
            Driver = driver;
        }

        private WebItem titleInput = new WebItem(
            "//input[@id='title_text']",
            "Поле Название сделки"
        );


        private WebItem saveButton = new WebItem(
            "//div[contains(@class,'ui-entity-section-control-edit-mode')]//button[contains(@class,'ui-btn-success')]",
            "Кнопка Сохранить"
        );

        private WebItem sliderFrame = new WebItem("//iframe[@class='side-panel-iframe']", "Фрейм слайдера");

        private WebItem addProductButton = new WebItem(
            "//div[contains(@class,'ui-entity-editor-product-summary-empty-list-container')]",
            "Кнопка Добавить товар"
        );

        private WebItem firstProductFromList = new WebItem(
            "(//div[contains(@class,'ui-selector-tab-content') and contains(@class,'ui-selector-tab-content-active')]//div[contains(@class,'ui-selector-item-box')])[1]",
            "Первый товар из списка"
        );

        private WebItem quantityField = new WebItem(
            "//div[@data-name='QUANTITY' and contains(@class,'main-grid-editor')]",
            "Поле Количество товара"
        );

        public CrmDealEditForm WaitUntilLoaded(int timeoutSec = 10)
        {
            WebDriverActions.SwitchToDefaultContent(Driver);
            sliderFrame.SwitchToFrame(Driver);
            titleInput.WaitElementDisplayed(timeoutSec, Driver);
            return this;
        }

        public CrmDealEditForm SetTitle(string title)
        {
            WebDriverActions.SwitchToDefaultContent(Driver);
            sliderFrame.SwitchToFrame(Driver);
            titleInput.WaitElementDisplayed(driver: Driver);
            titleInput.Click(Driver);
            titleInput.SendKeys(title, Driver);
            return this;
        }

        public CrmDealEditForm AddFirstProduct()
        {
            WebDriverActions.SwitchToDefaultContent(Driver);
            sliderFrame.SwitchToFrame(Driver);

            addProductButton.WaitElementDisplayed(driver: Driver);

            try
            {
                addProductButton.Click(Driver);
            }
            catch (ElementClickInterceptedException)
            {
                WebDriverActions.SwitchToDefaultContent(Driver);
                sliderFrame.SwitchToFrame(Driver);
                WebDriverActions.ExecuteJS("document.querySelector('.ui-entity-editor-product-summary-empty-list-title').click();");
            }

            firstProductFromList.WaitElementDisplayed(driver: Driver);
            firstProductFromList.Click(Driver);

            return this;
        }

        public CrmDealEditForm SetProductQuantity(int number)
        {
            WebDriverActions.SwitchToDefaultContent(Driver);
            sliderFrame.SwitchToFrame(Driver);

            quantityField.WaitElementDisplayed(driver: Driver);

            WebDriverActions.ExecuteJS(@"
                const el = document.querySelector(""div[data-name='QUANTITY'].main-grid-editor"");
                if (!el) throw new Error('QUANTITY element not found');

                el.scrollIntoView({block:'center'});
                el.focus();

                el.innerText = " + number + @";

                el.dispatchEvent(new Event('input',  { bubbles: true }));
                el.dispatchEvent(new Event('change', { bubbles: true }));
                el.dispatchEvent(new Event('blur',   { bubbles: true }));
            ");

            return this;
        }

        public void Save()
        {
            WebDriverActions.SwitchToDefaultContent(Driver);
            sliderFrame.SwitchToFrame(Driver);

            saveButton.WaitElementDisplayed(driver: Driver);
            saveButton.Click(Driver);
        }
    }
}