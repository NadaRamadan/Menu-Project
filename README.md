# Menu-Project
Menu Project
This project is a basic Menu Viewer built using ASP.NET Core MVC.
It displays a list of dishes and detailed information about each dish, including its ingredients.

Features
View a list of all available dishes.

View detailed information about each dish and its ingredients.

Technologies Used
.NET Core

ASP.NET Core MVC

Entity Framework Core

Project Structure
Models
Dish

Represents a dish.

Properties: Id, Name, Description, Price, etc.

Ingredient

Represents an ingredient.

Properties: Id, Name, Unit, etc.

MenuIngredient

Represents the relationship between dishes and ingredients.

Properties: DishId, IngredientId, QuantityUsed, etc.

Controllers
DishController

(You may also have IngredientController or similar if needed.)

Views
Each model mainly has:

Index: A page to display a list of items.

Details: A page to display details of a specific item.
