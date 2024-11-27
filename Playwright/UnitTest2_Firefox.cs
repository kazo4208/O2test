using Microsoft.Playwright;
namespace Playwright;

public partial class Tests
{
    [SetUp]
    public void SetupFirefox()
    {
    }

    [Test]
    public async Task Test2()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url: "https://o2.sk");
        await page.ClickAsync(selector: "text=Telefóny a zariadenia");
        //await page.GetByText("Telefóny a zariadenia").ClickAsync();
        Console.WriteLine("Navigated to Telefóny a zariadenia");
        await page.ClickAsync(selector: "text=Telefóny");
        //await page.GetByText("Telefóny").ClickAsync();
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
        await page.GetByTestId("chooseTariff.submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        //await page.GetByTestId("teansaction.activation").GetByLabel("").CheckAsync();
        await page.Locator("o2-button").Filter (new LocatorFilterOptions { HasText = "Pridať do košíka" }).ClickAsync();
        await page.GetByTestId("crossSell.submit").ClickAsync();
        await page.GetByTestId("hwSliderPage.submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať do košíka" }).ClickAsync();
        await page.GetByTestId("cart-summary__proceed-to-checkout")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Prejsť k osobným údajom" }).ClickAsync();
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
        await page.GetByTestId("idCardNumber").GetByLabel("").FillAsync("ML910145");
        await page.GetByTestId("idCardValidity").GetByRole(AriaRole.Textbox).ClickAsync();
        await page.GetByTestId("idCardValidity").GetByRole(AriaRole.Textbox).FillAsync("28.12.2025");
        await page.GetByTestId("idCardNumber").GetByLabel("").ClickAsync();
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await page.GetByText("Kartou online").ClickAsync();
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await browser.CloseAsync();
    }
}