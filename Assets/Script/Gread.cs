using System;

public class Gread{
    public Gread(GreadSystem greadSystem,float posx,float posy){
        this.greadSystem = greadSystem;
        x=posx;
        y=posy;
    }
    public ICollidible collidible;
    public ICollectable collectable;
    public GreadSystem greadSystem;
    public float x;
    public float y;
    public Gread GetGread(Snake.Direction direction){
        switch(direction){
            case Snake.Direction.North:
                return Up;
            case Snake.Direction.West:
                return Left;
            case Snake.Direction.South:
                return Down;
            case Snake.Direction.East:
                return Right;
            default:
                return null;
        }
    }

    public bool isEmpty()
    {
        return collidible == null && collectable == null;
    }

    public Gread Left=>greadSystem.GetGread(x-GreadSystem.BlockSize,y);
    public Gread Right=>greadSystem.GetGread(x+GreadSystem.BlockSize,y);
    public Gread Up=>greadSystem.GetGread(x,y+GreadSystem.BlockSize);
    public Gread Down=>greadSystem.GetGread(x,y-GreadSystem.BlockSize);
}