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
        await browser.CloseAsync();
     }
}