using Microsoft.Extensions.Logging;
using OpusMajor.LibProcess;

namespace OpusMajor.GitTools;

public class GitRunner
{
    private readonly ExternalApplication _git;

    public GitRunner(IProcessRunner processRunner, ILogger<GitRunner>? log = null)
    {
        _git = new ExternalApplication(processRunner, "git", null,
            s => log?.LogDebug("GIT: {Message}", s),
            s => log?.LogWarning("GITERR: {Message}", s),
            n => n == 0);
    }

    public async Task Execute(string directory, params string[] arguments)
    {
        await _git.Run(arguments, directory);
    }

}