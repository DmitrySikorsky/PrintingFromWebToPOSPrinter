// Copyright © 2018 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Drawing;

namespace Printer
{
  public class ReceiptPrint : PrintBase
  {
    private string orderId;
    //private Order order;

    // TODO: we don't need the orderId paramter, it is here just as an illustration
    public void Print(string printerName, string orderId)
    {
      this.orderId = orderId;
      // TODO: use this code if you need to get some data from your REST API
      //using (var httpClient = new HttpClient())
      //{
      //  httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
      //  this.order = httpClient.GetAsync($"<REST API method URL>").Result.Content.ReadAsAsync<Order>().Result;
      //}

      this.Print(printerName, this.PrintCustomerFragment);
    }

    private void PrintCustomerFragment(Graphics g)
    {
      float y = 0;

      using (Image logoImage = Image.FromFile(@"C:\<Path to your application>\pizzarium_printable.png"))
        g.DrawImage(logoImage, 0, 0, 40, 18);

      y += 18; // Image logo height
      y += 10; // Empty line
      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Order ID", 0.8f, fontSize: 14f),
        new TextColumn(this.orderId, 0.2f, StringAlignment.Far, 14f)
      );

      y += 10; // Empty line
      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Margarita pizza\r\n1×10.00", 0.8f),
        new TextColumn(10f.ToString("0.00"), 0.2f, StringAlignment.Far)
      );

      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Neapolitan pizza\r\n2×12.50", 0.8f),
        new TextColumn(25f.ToString("0.00"), 0.2f, StringAlignment.Far)
      );

      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Cola\r\n1×5.00", 0.8f),
        new TextColumn(5f.ToString("0.00"), 0.2f, StringAlignment.Far)
      );

      y += 10; // Empty line
      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Subtotal", 0.8f),
        new TextColumn(40f.ToString("0.00"), 0.2f, StringAlignment.Far)
      );

      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Discount", 0.8f),
        new TextColumn(0f.ToString("0.00"), 0.2f, StringAlignment.Far)
      );

      y += this.DrawTextColumns(
        g, y,
        new TextColumn($"Total", 0.8f, fontSize: 14f),
        new TextColumn(40f.ToString("0.00"), 0.2f, StringAlignment.Far, 14f)
      );
    }
  }
}