using Microsoft.Playwright;
namespace Playwright;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync(url: "http://o2.sk");
        await page.ClickAsync(selector:"text=Telefóny a zariadenia");
        Console.WriteLine("Navigated to Telefóny a zariadenia");
        await page.ClickAsync(selector:"text=Telefóny");
        Console.WriteLine("Navigated to Telefony");
        var items = await page.QuerySelectorAllAsync("text=Xiaomi 14T, Šedý");
        Console.WriteLine("Found items");
        Console.WriteLine(items.Count);
        var itemsInStock = new List<IElementHandle>();
        Console.WriteLine("Items in stock list created");
        foreach (var item in items)
        {
            Console.WriteLine("starting loop");
            if ((await item.InnerTextAsync()).Contains("na sklade"))
            {
                itemsInStock.Add(item);
                Console.WriteLine("Found item in stock, added to list");
            }
        }

        if (itemsInStock.Count > 0)
        {
            var random = new Random();
            int randomIndex = random.Next(itemsInStock.Count);
            var selectedItem = items.ElementAt(randomIndex);
            await selectedItem.ClickAsync();
        }
        else
        {
            Console.WriteLine("no items found");
            return;
        }
    }
}