using Microsoft.EntityFrameworkCore;
using Playday.GraphQL.API.Graph.Cars;
using Playday.GraphQL.API.Graph.Houses;
using Playday.GraphQL.API.Graph.Scooters;
using Playday.GraphQL.API.Graph.Bikes;
using Playday.GraphQL.API.Graph.Appartments;
using Playday.GraphQL.Common.ExceptionHandling;
using Playday.GraphQL.Common.Validation;
using Playday.GraphQL.Database;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

var connection = configuration.GetConnectionString("SqlServer");
var graphQLServer = services.AddGraphQLServer();
graphQLServer.AddFiltering()
	.AddSorting()
	.AddFiltering()
	.RegisterDbContext<PlaydayDbContext>(DbContextKind.Pooled)
	.AddQueryType()
	.AddMutationType();

services
	.AddDbContextPool<PlaydayDbContext>(options => options.UseSqlServer(connection))
	.ConfigureExceptionHandling(graphQLServer)
	.ConfigureValidation(graphQLServer)
	.ConfigureCars(graphQLServer)
	.ConfigureBikes(graphQLServer)
	.ConfigureScooters(graphQLServer)
	.ConfigureAppartments(graphQLServer)
	.ConfigureHouses(graphQLServer);


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

	var serviceProvider = scope.ServiceProvider;
	var dbContext = serviceProvider.GetRequiredService<PlaydayDbContext>();
	dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();
