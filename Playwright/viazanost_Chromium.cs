using Microsoft.Playwright;
namespace Playwright;

public partial class Tests
{
    [SetUp]
    public void SetupChromiumviazanost()
    {
    }

    [Test]
    public async Task Test1viazanost()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url: "https://www.o2.sk");
        //await page.ClickAsync(selector: "text=Internet a TV");
        await page.GetByTestId("mainNavigation.menuItem.3").ClickAsync();
        Console.WriteLine("Navigated to Telefóny a zariadenia");
        //await page.ClickAsync(selector: "text=Vykúpenie z viazanosti");
        await page.GetByTestId("mainNavigation.megaMenu.submenuItem.16").ClickAsync();
        await page.GetByRole(AriaRole.Link, new() { Name = "Zadať adresu" }).ClickAsync();
        await page.GetByPlaceholder("Ulica, Mesto").FillAsync("Hany Meličkovej 2983/15A, Bratislava-Karlova Ves, 84105, Bratislava IV");
        await page.GetByRole(AriaRole.Option, new PageGetByRoleOptions {Name = "Hany Meličkovej 2983/15A, Bratislava-Karlova Ves, 84105, Bratislava IV"}).ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Overiť dostupnosť" }).ClickAsync();
        var element = page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Vybrať internet" });
        await element.First.ClickAsync();
        await page.Locator("span").Filter(new LocatorFilterOptions{HasText = "Vyberte"}).First.ClickAsync();
        await page.GetByRole(AriaRole.Option, new PageGetByRoleOptions { Name = "3" }).ClickAsync();
        await page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Pokračovať ďalej" }).ClickAsync();
        await page.ClickAsync(selector: "text=Pokračovať ako nový zákazník");
        await page.GetByTestId("extenderCheckbox0").CheckAsync();
        await page.GetByTestId("go-next-step").GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await page.GetByTestId("radio-item-SELF_SERVICE").CheckAsync();
        await page.GetByTestId("go-next-step").GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        //await page.GetByTestId("cross-sell-addon__predplatne-hbomax").CheckAsync();
        //await page.GetByTestId("cross-sell-addon__predplatne-netflix-basic").CheckAsync();
        //await page.GetByTestId("cross-sell-addon__predplatne-o2tv").CheckAsync();
        await page.GetByTestId("crossSell.submit").ClickAsync();
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
        await page.GetByTestId("idCardNumber").GetByLabel("").FillAsync("MI910145");
        await page.GetByTestId("idCardValidity").GetByRole(AriaRole.Textbox).ClickAsync();
        await page.GetByTestId("idCardValidity").GetByRole(AriaRole.Textbox).FillAsync("28.12.2025");
        await page.GetByTestId("idCardNumber").GetByLabel("").ClickAsync();
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await page.GetByTestId("checkout-submit")
            .GetByRole(AriaRole.Button, new LocatorGetByRoleOptions { Name = "Pokračovať" }).ClickAsync();
        await browser.CloseAsync();
     }
}