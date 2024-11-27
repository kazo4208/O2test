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
        await page.GetByText("Vaša adresa").ClickAsync();
        await page.GetByRole(AriaRole.Button, new() { Name = "Overiť dostupnosť" }).ClickAsync();
        await browser.CloseAsync();
     }
}