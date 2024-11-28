using Microsoft.Playwright;
namespace Playwright;

public partial class Tests
{
    [SetUp]
    public void SetupChromium()
    {
    }

    [Test]
    public async Task Test3()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        { Headless = false });
        var page = await browser.NewPageAsync();
        var context = await browser.NewContextAsync(new()
        {
            RecordVideoDir = "videos/",
            RecordVideoSize = new RecordVideoSize { Width = 1280, Height = 720 }
        });
        await page.GotoAsync(url: "https://o2.sk");
        //await page.ClickAsync(selector: "text=Telefóny a zariadenia");
        await page.GetByTestId("mainNavigation.menuItem.5").ClickAsync();
        Console.WriteLine("Navigated to Telefóny a zariadenia");
        //await page.ClickAsync(selector: "text=Telefóny");
        await page.GetByTestId("mainNavigation.megaMenu.title.7").ClickAsync();
        Console.WriteLine("Navigated to Telefony");
        //await page.GotoAsync(url: "http://o2.sk/e-shop/produkt/xiaomi-14t-sedy");
        await page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Xiaomi 14T, Šedý Vianočná" })
            .ClickAsync();
        await page.ClickAsync(selector: "text=Kúpiť na splátky k paušálu");
        Console.WriteLine("Navigated to kupit na splatky");
        await page.ClickAsync(selector: "text=Pokračovať ako nový zákazník");
        await page.Locator("span", new PageLocatorOptions { HasText = "Bezstarostný O2 Paušál 39 €" }).ClickAsync();
        await page.GetByRole(AriaRole.Option, new PageGetByRoleOptions { Name = "Pohodový O2 Paušál 29 €" })
            .ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot1.jpg" });
        await page.GetByTestId("chooseTariff.submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot2.jpg" });
        await page.Locator("o2-button").Filter (new LocatorFilterOptions { HasText = "Pridať do košíka" }).ClickAsync();
        await page.GetByTestId("crossSell.submit").ClickAsync();
        await page.GetByTestId("hwSliderPage.submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať do košíka" }).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot3.jpg" });
        await page.GetByTestId("cart-summary__proceed-to-checkout")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Prejsť k osobným údajom" }).ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot4.jpg" });
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await page.GetByTestId("firstName").GetByLabel("").FillAsync("Martin");
        await page.GetByTestId("lastName").GetByLabel("").FillAsync("Klingáč");
        await page.GetByTestId("email").GetByLabel("").FillAsync("mklin@gmail.com");
        await page.GetByTestId("contactPhone").GetByLabel("").FillAsync("0901234567");
        await page.GetByTestId("street").GetByLabel("").FillAsync("Hany Meličkovej");
        await page.GetByTestId("streetNumber").GetByLabel("").FillAsync("10");
        await page.GetByTestId("city").GetByLabel("").FillAsync("Bratislava-Karlova Ves");
        await page.GetByTestId("zip").GetByLabel("").FillAsync("84105");
        await page.GetByTestId("birthNumber").GetByLabel("").FillAsync("961122/7703");
        await page.GetByTestId("idCardNumber").GetByLabel("").FillAsync("MI910145");
        await page.GetByTestId("idCardValidity").GetByRole(AriaRole.Textbox).ClickAsync();
        await page.GetByTestId("idCardValidity").GetByRole(AriaRole.Textbox).FillAsync("28.12.2025");
        await page.GetByTestId("idCardNumber").GetByLabel("").ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot5.jpg" });
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await page.GetByText("Kartou online").ClickAsync();
        await page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshot6.jpg" });
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await context.CloseAsync();
        await browser.CloseAsync();
     }
}