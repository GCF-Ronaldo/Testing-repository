using CliWrap;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();

app.MapGet("/", () => "Hello World!");

app.MapPost("/", (string filePath) => new GitCommand().SendToRepository(filePath));

app.UseSwaggerUI();


app.Run();
public class GitCommand
{
    public string User { get; private set; }
    public string Email { get; private set; }

    public GitCommand() { }

    public GitCommand(string user = "User", string email = "Email")
    {
        User = user;
        Email = email;  
    }

    public async Task<string> SendToRepository(string filePath)
    {
        //var cmd = await Cli.Wrap("git")
        ////.WithArguments(new[] { "init", "&", "git", "add", ".", "&", "git", "commit" , "-m", "'Teste'" })
        ////.ExecuteAsync();
        ////var cmd = await Cli.Wrap("git")
        //.WithArguments(args => args
        //.Add("init")
        //.Add("&")
        ////.Add("git add .")
        //.Add("add")
        //.Add(".")
        //.Add("&")
        ////.Add("git commit -m 'Teste'"))
        //.Add("commit")
        //.Add("-m")
        //.Add("'Teste"))
        //.WithWorkingDirectory($@"{filePath}").ExecuteAsync();

        string strCmdText1 = $@"{filePath}";
        System.Diagnostics.Process.Start("CMD.exe", strCmdText1);
        string srtCmdText2 = "git init & git add . & git commit -m 'Teste'";
        System.Diagnostics.Process.Start("CMD.exe", srtCmdText2);

        return $"O caminho é: {filePath}";

        // Criar uma branch orfã do projeto e enviar pra um único repositório
    }

    public void CloneRepository(string filePath)
    {
        // Trazer da branch o projeto
    }


}
