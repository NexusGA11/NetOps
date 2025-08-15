// Namespaces das equipes no nível superior
namespace RedRemoteControlCarTeam
{
    public class RemoteControlCar { }
}

namespace BlueRemoteControlCarTeam
{
    public class RemoteControlCar { }
}

// Namespace do Builder também no nível superior
namespace Combined
{
    public static class CarBuilder
    {
        public static BlueRemoteControlCarTeam.RemoteControlCar BuildBlue()
        {
            return new BlueRemoteControlCarTeam.RemoteControlCar();
        }

        public static RedRemoteControlCarTeam.RemoteControlCar BuildRed()
        {
            return new RedRemoteControlCarTeam.RemoteControlCar();
        }
    }
}
