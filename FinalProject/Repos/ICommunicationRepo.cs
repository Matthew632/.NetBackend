using FinalProject.Models;

namespace FinalProject.Repos
{
    public interface ICommunicationRepo
    {
        Helper GetHelper();
        Helper HelperPatch(PatchHelper patchHelper);
    }
}