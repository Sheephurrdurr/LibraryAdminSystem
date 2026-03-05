using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application;

using var context = new LibraryContext();
var queryService = new QueryService(context);

await context.Database.MigrateAsync();
await DbSeeder.SeedAsync(context);

var activeLoans = await queryService.GetAllActiveLoans();

