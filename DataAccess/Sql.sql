--create table Recipes(
--	Id int not null primary key identity(1,1),
--	Name varchar(300) not null,
--	Description varchar(max)
--);

--create table Ingredients(
--	Id int not null primary key identity(1,1),
--	Name varchar(100) not null,
--	Type int not null
--);

--create table IngredientsInRecipe(
--	IngredientId int foreign key references Ingredients(Id) on delete cascade,
--	RecipeId int foreign key references Recipes(Id) on delete cascade,
--	Amount int,
--	Unit varchar(max),
--	constraint IIR_PK primary key (IngredientId, RecipeId)
--);

--create proc dbo.GetAllIngredients
--as
--begin
--set nocount on;

--select * from Ingredients;

--end




--create proc dbo.GetAllIngredientsFull
--as
--begin
--set nocount on;

--select
--	Ingredients.Id,
--	Ingredients.Name,
--	Ingredients.Type,
--	IngredientsInRecipe.Amount,
--	IngredientsInRecipe.RecipeId,
--	IngredientsInRecipe.Unit
--from IngredientsInRecipe
--inner join Ingredients on IngredientsInRecipe.IngredientId = Ingredients.Id

--end

--create proc dbo.GetIngredient
--@IngredientId int
--as
--begin
--set nocount on;

--select * from Ingredients
--where Id = @IngredientId;

--end

--alter proc dbo.newingredient
--@name varchar(max),
--@type int
--as
--begin

--insert into ingredients(name, type)
--values
--	(@name, @type)
--end

--create proc dbo.UpdateIngredient
--@IngredientId int,
--@Name varchar(max),
--@Type int
--as
--begin

--update Ingredients
--set Name = @Name, Type = @Type
--where Id = @IngredientId

--end

--end
--create proc dbo.DeleteIngredient
--@IngredientId int
--as
--begin
--set nocount on;

--delete from Ingredients
--where Id = @IngredientId

--end




--create proc dbo.GetIngredientsInRecipe
--@RecipeId int
--as
--begin
--set nocount on;

--select
--	Ingredients.Id,
--	Ingredients.Name,
--	Ingredients.Type,
--	IngredientsInRecipe.Amount,
--	IngredientsInRecipe.RecipeId,
--	IngredientsInRecipe.Unit
--from IngredientsInRecipe
--inner join Ingredients on IngredientsInRecipe.IngredientId = Ingredients.Id 
--where RecipeId = @RecipeId

--end


--create proc dbo.GetIngredientsInRecipes
--as
--begin
--set nocount on;

--select * from IngredientsInRecipe;

--end


--create proc dbo.AddNewIngredientToRecipe
--@IngredientId int,
--@RecipeId int,
--@Amount int,
--@Unit int
--as
--begin

--insert into IngredientsInRecipe(IngredientId, RecipeId, Amount, Unit)
--values
--	(@IngredientId, @RecipeId, @Amount, @Unit)

--end


--create proc dbo.UpdateIngredientInRecipe
--@IngredientId int,
--@RecipeId int,
--@Amount int,
--@Unit int
--as
--begin

--update IngredientsInRecipe
--set Amount = @Amount, Unit = @Unit
--where IngredientId = @IngredientId and RecipeId = @RecipeId

--end


--create proc dbo.RemoveIngredientFromRecipe
--@RecipeId int,
--@IngredientId int
--as
--begin

--delete from IngredientsInRecipe
--where RecipeId = @RecipeId and IngredientId = @IngredientId

--end




--create proc dbo.NewRecipe
--@Name varchar(max),
--@Description varchar(max)
--as
--begin
--set nocount on;

--insert into Recipes(Name, Description)
--output inserted.Id
--values
--	(@Name, @Description)

--end


--create proc dbo.GetAllRecipes
--as
--begin
--set nocount on;

--select * from Recipes

--end


--create proc dbo.UpdateRecipe
--@RecipeId int,
--@Name varchar(max),
--@Description varchar(max)
--as
--begin

--update Recipes
--set Name = @Name, Description = @Description
--where Id = @RecipeId

--end


--create proc dbo.GetRecipe
--@RecipeId int
--as
--begin
--set nocount on;

--select * from Recipes
--where Id = @RecipeId

--end


--create proc dbo.DeleteRecipe
--@RecipeId int
--as
--begin

--delete from Recipes
--where Id = @RecipeId

--end

