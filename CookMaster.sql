

CREATE TABLE Recipe(
recipeId INT PRIMARY KEY  IDENTITY (1, 1) NOT NULL ,
recipeName NVARCHAR (500)  NOT NULL,
cuisine NVARCHAR (500) ,
description NVARCHAR (500) ,
instruction NVARCHAR (1000)  NOT NULL,
prepTime NVARCHAR (50)  NOT NULL,
rating NVARCHAR (50) ,
prepVideoUrl NVARCHAR (50),
image  VARBINARY(MAX) ,
complexity NVARCHAR (30) ,
);


CREATE TABLE Ingredient(
ingredientId INT PRIMARY KEY  IDENTITY (1, 1) NOT NULL ,
ingredientName NVARCHAR (100)  NOT NULL
);
  
CREATE TABLE Recipe_Ingredient(
recipeId INT NOT NULL,
ingredientId INT NOT NULL,
measurement  NVARCHAR (50)  NOT NULL,
  PRIMARY KEY (recipeId, ingredientId),
  CONSTRAINT FK_recipeId FOREIGN KEY ([recipeId]) REFERENCES Recipe (recipeId),
  CONSTRAINT FK_ingredientId FOREIGN KEY ([ingredientId]) REFERENCES Ingredient (ingredientId)
);

insert into Recipe(recipeName,cuisine,description,instruction,prepTime,rating,prepVideoUrl,complexity) values('Tom Yum Soup','Thai','test','test','1 hour','5','https://youtu.be/hXaaZiMgvgI','Easy');
insert into Recipe(recipeName,cuisine,description,instruction,prepTime,rating,prepVideoUrl,complexity) values('Pad Thai Noodles','Thai','test','test','1 hour','5','https://youtu.be/hXaaZiMgvgI','Easy');

insert into Ingredient(ingredientName) values('Salt');
insert into Ingredient(ingredientName) values('Shrimp');
insert into Ingredient(ingredientName) values('Sugar');
insert into Ingredient(ingredientName) values('Chilli');
insert into Ingredient(ingredientName) values('Chicken');
insert into Ingredient(ingredientName) values('Fish');
insert into Ingredient(ingredientName) values('Carrot');
insert into Ingredient(ingredientName) values('Strawberry');
insert into Ingredient(ingredientName) values('Water');


insert into RecipeIngredient(recipeId,ingredientId,measurement) values(1,1,'1 tsp');

insert into RecipeIngredient(recipeId,ingredientId,measurement) values(1,2,'100g');
insert into RecipeIngredient(recipeId,ingredientId,measurement) values(1,6,'100g');
insert into RecipeIngredient(recipeId,ingredientId,measurement) values(1,9,'2 Cups');
insert into RecipeIngredient(recipeId,ingredientId,measurement) values(1,4,'3 nos');

insert into RecipeIngredient(recipeId,ingredientId,measurement) values(2,1,'1 tsp');

insert into RecipeIngredient(recipeId,ingredientId,measurement) values(2,2,'100g');
insert into RecipeIngredient(recipeId,ingredientId,measurement) values(2,6,'100g');
insert into RecipeIngredient(recipeId,ingredientId,measurement) values(2,9,'2 Cups');
insert into RecipeIngredient(recipeId,ingredientId,measurement) values(2,4,'3 nos');