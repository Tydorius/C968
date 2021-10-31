# C968 Software I – C# – C968

## Introduction

The goal of this document is to simply act as a checklist for the items which I believe I have covered.

# I. User Interface

Create a C# application with a graphical user interface (GUI) based on the attached “GUI Mock-Up.” Write code to display each of the following forms in the GUI:

**A.  A main form, showing the following controls:**
- [x] buttons for “Add,” “Modify,” “Delete,” “Search” for parts and products, and “Exit”
- [x] lists for parts and products
- [x] text boxes for searching for parts and products
- [x] title labels for parts, products, and the application title

**B.  An add part form, showing the following controls:**
- [x] radio buttons for “In-House” and “Outsourced” parts
- [x] buttons for “Save” and “Cancel”
- [x] text boxes for ID, name, inventory level, price, max and min values, and company name or machine ID
- [x] labels for ID, name, inventory level, price/cost, max and min values, the application title, and company name or machine ID

**C.  A modify part form, with fields that populate with data from an existing Part, showing the following controls:**
- [x] radio buttons for “In-House” and “Outsourced” parts
- [x] buttons for “Save” and “Cancel”
- [x] text boxes for ID, name, inventory level, price, max and min values, and company name or machine ID
- [x] labels for ID, name, inventory level, price, max and min values, the application title, and company name or machine ID

**D .  An add product form, showing the following controls:**
- [x] buttons for “Save,” “Cancel,” “Add” part, and “Delete” part
- [ x text boxes for ID, name, inventory level, price, and max and min values
- [x] labels for ID, name, inventory level, price, max and min values, and the application
- [x] a grid view for all parts
- [x] a grid view for parts associated with the product
- [x] a “Search” button and a text field with an associated list for displaying the results of the search

**E.  A modify product form, with fields that populate with data from an existing product, showing the following controls:**
- [x] buttons for “Save,” “Cancel,” “Add” part, and “Delete” part
- [x] text boxes for ID, name, inventory level, price, and max and min values
- [x] labels for ID, name, inventory level, price, max and min values, and the application “all candidate parts”
- [x] a grid view for parts associated with the product
- [x] a “Search” button and a text box with associated list for displaying the results of the search

# II. Application

Now that you’ve created the GUI, write code to create the class structure provided in the attached “UML (unified modeling language) Class Diagram.” Enable each of the following capabilities in the application:

**F.  Using the attached “UML Class Diagram,” create appropriate classes and instance variables with the following criteria:**
- [x] five classes with the all associated properties
- [x] variables are accessible/modifiable through properties

**G.  Add the following functionalities to the main form, using the methods provided in the attached “UML Class Diagram”:**
- [x] redirect the user to the “Add Part,” “Modify Part,” “Add Product,” or “Modify Product” forms
- [x] delete a selected part or product from the grid view
- [x] search for a part or product and display matching results
- [x] exit the main form

**H.  Add the following functionalities to the part forms, using the methods provided in the attached “UML Class Diagram”:**
_1.   “Add Part” form_
- [x] select “In-House” or “Outsourced”
- [x] enter name, inventory level, price, max and min values, and company name or machine ID
- [x] save the data and then redirect to the main form
- [x] cancel or exit out of this form and go back to the main form

_2.   “Modify Part” form_
- [x] select “In-House” or “Outsourced”
- [x] modify or change data values
- [x] save modifications to the data and then redirect to the main form
- [x] cancel or exit out of this form and go back to the main form

**I.  Add the following functionalities to the product forms, using the methods provided in the attached “UML Class Diagram”:**
_1.   “Add Product” form_
- [x] enter name, inventory level, price, and max and min values
- [x] save the data and then redirect to the main form
- [x] associate one or more parts with a product
- [x] remove or disassociate a part from a product
- [x] cancel or exit out of this form and go back to the main form

_2.   “Modify Product” form_
- [x] modify or change data values
- [x] save modifications to the data and then redirect to the main form
- [x] associate one or more parts with a product
- [x] remove or disassociate a part from a product
- [x] cancel or exit out of this form and go back to the main form

**J.  Write code to address the following conditions with exception handling code:**
- [x] Detect non-numeric values in textboxes that expect numeric values
- [x] Min should be less than Max; and Inv should be between those two values
- [x] Prevent the user from deleting a product that has a Part associated with it
- [x] Confirm “Delete” actions

**File Restrictions**
- File name may contain only letters, numbers, spaces, and these symbols: ! - _ . * ' ( )
- File size limit: 200 MB
- File types allowed: doc, docx, rtf, xls, xlsx, ppt, pptx, odt, pdf, txt, qt, mov, mpg, avi, mp3, wav, mp4, wma, flv, asf, mpeg, wmv, m4v, svg, tif, tiff, jpeg, jpg, gif, png, zip, rar, tar, 7z

# Rubric Scoring:
Main Form
Main Form Functions
Add Part Form
Add Part Form Functions
Modify Part Form
Modify Part Form Functions
Add Product Form
Modify Product Form
Class Structure
Exception Handling Code
Professional Communication
