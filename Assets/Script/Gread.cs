public class Gread{
    public Gread(GreadSystem greadSystem,float posx,float posy){
        this.greadSystem = greadSystem;
        x=posx;
        y=posy;
    }
    public ICollidible collidible;
    public GreadSystem greadSystem;
    public float x;
    public float y;
    public Gread Left=>greadSystem.GetGread(x-GreadSystem.BlockSize,y);
    public Gread Right=>greadSystem.GetGread(x+GreadSystem.BlockSize,y);
    public Gread Up=>greadSystem.GetGread(x,y-GreadSystem.BlockSize);
    public Gread Down=>greadSystem.GetGread(x,y+GreadSystem.BlockSize);
}