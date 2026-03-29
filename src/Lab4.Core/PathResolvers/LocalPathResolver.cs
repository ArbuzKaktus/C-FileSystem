using Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers;

public class LocalPathResolver : IPathResolver
{
    public PathResolveResult Resolve(string path, string currentPath, string rootPath)
    {
        string resolvedPath = Path.GetFullPath(Path.Combine(currentPath, path));

        if (!path.StartsWith('/')) return ProvideWithConnectionPath(resolvedPath, rootPath);

        path = path.TrimStart('/');
        resolvedPath = Path.GetFullPath(Path.Combine(rootPath, path));

        return ProvideWithConnectionPath(resolvedPath, rootPath);
    }

    private PathResolveResult ProvideWithConnectionPath(string path, string rootPath)
    {
        string absolutePath = Path.GetFullPath(path);
        string absoluteRootPath = Path.GetFullPath(rootPath);

        return !absolutePath.StartsWith(absoluteRootPath, StringComparison.OrdinalIgnoreCase)
            ? new PathResolveResult.Failure()
            : new PathResolveResult.Success(absolutePath);
    }
}