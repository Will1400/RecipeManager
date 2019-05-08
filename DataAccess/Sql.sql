--create table Recipes(
--	Id int not null primary key identity(1,1),
--	Name varchar(max) not null,
--	Description varchar(max)
--);

--create table Ingredients(
--	Id int not null primary key identity(1,1),
--	Name varchar(max) not null,
--	Type int not null
--);

--create table IngredientsInRecipe(
--	IngredientId int foreign key references Ingredients(Id),
--	RecipeId int foreign key references Recipes(Id),
--	Amount int,
--	Unit varchar(max),
--	constraint IIR_PK primary key (IngredientId, RecipeId)
--);

