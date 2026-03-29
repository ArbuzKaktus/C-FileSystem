using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers.Interfaces;

public interface IPathResolver
{
    PathResolveResult Resolve(string path, string currentPath, string rootPath);
}