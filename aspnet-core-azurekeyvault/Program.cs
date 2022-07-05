var builder = WebApplication.CreateBuilder(args);

string keyVaultAddress = builder.Configuration["KEYVAULT_ADDRESS"];
string keyVaultTenantId = builder.Configuration["KEYVAULT_TENANTID"];
string keyVaultClientId = builder.Configuration["KEYVAULT_CLIENTID"];
string keyVaultClientSecret = builder.Configuration["KEYVAULT_CLIENTSECRET"];

Azure.Identity.ClientSecretCredential credential = new(keyVaultTenantId, keyVaultClientId, keyVaultClientSecret);

builder.Configuration.AddAzureKeyVault(new Uri(keyVaultAddress), credential);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();