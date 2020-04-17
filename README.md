# Printing From Web to POS Printer
This is a demo application for the
“[How to Print From a Web Page to a POS Printer](https://medium.com/@dmitry.a.sikorsky/how-to-print-from-a-web-page-to-a-pos-printer-8d5b39fc975b)”
post on the [Dmitry Sikorsky’s blog](https://medium.com/@dmitry.a.sikorsky).
It shows how to send print requests from a web page directly to a POS (or any other) printer.

The result looks like this:
![Printing From Web to POS Printer]((result.jpg))
*Printing From Web to POS Printer*

## Using the Application

1. Connect your printer and install all the required drivers. It should be visible in the system.
2. Set the correct logo filepath inside the \PrintingFromWebToPOSPrinter\Printer\ReceiptPrint.cs file.
3. Rebuild the application.
4. Set the corrent application path inside the \PrintingFromWebToPOSPrinter\print.reg file and execute it (or add the protocol manually).
5. Open the \PrintingFromWebToPOSPrinter\test.html file and click the Print test recepit! link.
6. You should see the printed receipt.