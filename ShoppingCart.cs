/*------------------------------------------------------------------------------
 *                      HTBLA-Leonding / Class: 3ACIF                           
 *------------------------------------------------------------------------------
 *                      Jan Ritt                                                
 *------------------------------------------------------------------------------
 *  Description:  User can enter an arbitrary amount of products, their price,  
 *                amount and gets a bill, depending on the value and country.    
 *------------------------------------------------------------------------------
*/
using System;
using System.Text;
using System.Threading;


namespace ShoppingCart
{
  internal class Program
  {
    static void Main()
    {
      char choice;
      bool testDouble,
           testInt;
      string productAmountString,
             country,
             formattedTaxAmount,
             formattedNetto,
             formattedBrutto,
             formattedFull,
             productNettoString;
      int inputCounter = 0,
          productAmount;
      double present = 2.50,
             deliveryCost = 5.90,
             taxCountry,
             taxAmount,
             billNetto,
             billBrutto,
             billFull,
             productNetto;

      /*  INTRODUCTION  */
      Console.Clear();
      Console.Write("\n   *****************" +
                    "\n   * Shopping Cart *" +
                    "\n   *****************" +
                    "\n══════════════════════════════════");

      do /* LOOPED INPUT */
      {
        /// increase counter
        inputCounter++;
        /// header
        Console.Write("\n =============================" +
                     $"\n  Eingabe von Produkt Nr {inputCounter}" +
                      "\n ---------------------------");
        /// PROMPT for valid netto price
        do
        {
          Console.Write("\n  ? Netto-Stückpreis:      ");
          productNettoString = Console.ReadLine();
          testDouble = double.TryParse(productNettoString, out productNetto);
        } while (!testDouble);
        /// PROMPT for valid product amount
        do
        {
          Console.Write("\n  ? Stückzahl:     x");
          productAmountString = Console.ReadLine();
          testInt = int.TryParse(productAmountString, out productAmount);
        } while (!testInt);
        /// get value
        billNetto = productNetto * productAmount;
        formattedNetto = billNetto.ToString("0.00");
        Console.Write($"\n  - Nettopreis der {productAmount} Produkte:" +
                      $"\n    {formattedNetto} EUR");
        /// PROMPT for valid present option
        do
        {
          Console.Write("\n  ? Geschenkoption \n    [ j / n ]  ");
          /// get present
          choice = Console.ReadKey().KeyChar;
          if (char.ToUpper(choice) == 'J')
          {
            Console.Write($"\n    zuzüglich {present * productAmount} EUR\n");
            billNetto = billNetto + present;
          }
          else if (char.ToUpper(choice) == 'N')
          {
            Console.Write("\n  - ohne Geschenkoption - \n");
          }
          else
            Console.Write("\n  → falsche Eingabe \n");
        } while ((char.ToUpper(choice) != 'J') && (char.ToUpper(choice) != 'N'));
        /// 
        Console.Write("\n ---------------------------");
        /// prompt for valid input repetition
        do
        {
          Console.Write("\n Weiteres Produkt eingeben? \n    [ j / n ]  ");
          choice = Console.ReadKey().KeyChar;
        } while ((char.ToUpper(choice) != 'J') && (char.ToUpper(choice) != 'N'));
        /// REPEAT if YES
      } while (char.ToUpper(choice) == 'J');

      /* DELIVERY */
      /// PROMPT for valid country
      do
      {
        Console.Write("\n  ? Lieferung nach \n    [ at / de ]  ");
        country = Console.ReadLine();
      } while ((country != "at") && (country != "de"));
      if (country == "at")
      {
        taxCountry = 20;
      }
      else
      {
        taxCountry = 19;
      }

      /* BILL CALCULATION & OUTPUT */
      /// header
      Console.Write("\n══════════════════════════════════" +
                    "\n   Ihre Rechnung" +
                    "\n---------------------------");
      /// calculate
      formattedNetto = billNetto.ToString("0.00");
      Console.Write("\n  - Nettopreis aller Produkte:" +
                   $"\n       {formattedNetto} EUR");
      /// brutto
      billBrutto = billNetto * ((100 + taxCountry) / 100);
      taxAmount = billBrutto - billNetto;
      formattedTaxAmount = taxAmount.ToString("0.00");
      Console.Write($"\n  {taxCountry}% - MWSt der Produkte:" +
                    $"\n       {formattedTaxAmount} EUR" +
                     "\n ---------------------------");
      formattedBrutto = billBrutto.ToString("0.00");
      Console.Write("\n  - Bruttopreis aller Produkte:" +
                   $"\n       {formattedBrutto} EUR");
      /// devlivery cost
      if (billBrutto < 29.9)
      {
        Console.Write($"\n  - Versandkosten: {deliveryCost} EUR" +
                       "\n ---------------------------");
        billFull = billBrutto + deliveryCost;
      }
      else { billFull = billBrutto; }
      ///
      formattedFull = billFull.ToString("0.00");
      /// FINAL BILL
      Console.Write("\n=============================" +
                    "\n  - Gesamtpreis:" +
                   $"\n       {formattedFull} EUR");
      /// wait a moment   
      Thread.Sleep(500);
      ///  EXIT PROMPT
      Console.Write("\n══════════════════════════════════" +
                    "\n Beenden mit beliebiger Taste ...");
      Console.ReadKey();
      Console.Clear();
    }
  }
}
