using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//建立res图集片段结构类//废弃项目20240310
public class ResourceStruct
{
    string id;
    string type;
    string parent;
    string res;
    ArrayList resources;

    public ResourceStruct()
    {
    }

    public ResourceStruct(string id, string type, string parent, string res, ArrayList resources)
    {
        this.id = id ?? throw new ArgumentNullException(nameof(id));
        this.type = type ?? throw new ArgumentNullException(nameof(type));
        this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
        this.res = res ?? throw new ArgumentNullException(nameof(res));
        this.resources = resources ?? throw new ArgumentNullException(nameof(resources));
    }
}

//建立图集结构类
public class ResourcesStruct
{
    string slot;
    string id;
    ArrayList path;
    string type;
    public ResourcesStruct()
    {
    }

    public ResourcesStruct(string slot, string id, ArrayList path, string type)
    {
        this.slot = slot;
        this.id = id;
        this.path = path;
        this.type = type;
    }
}

//建立Atlas结构类
public class AtlasStruct:ResourcesStruct
{
    bool atlas;
    int width;
    int height;
    public AtlasStruct()
    {
    }

    public AtlasStruct(bool atlas, int width, int height, string slot, string id, ArrayList path, string type) :base(slot,id,path,type)
    {
        this.atlas = atlas;
        this.width = width;
        this.height = height;
    }
}

//建立Sprite结构类
public class SpriteStruct : ResourcesStruct
{
    string parent;
    int ax;
    int ay;
    int aw;
    int ah;
    int x;
    int y;
    public SpriteStruct()
    {
    }

    public SpriteStruct(string parent, int ax, int ay, int aw, int ah, int x, int y, string slot, string id, ArrayList path, string type) : base(slot, id, path, type)
    {
        this.parent = parent ?? throw new ArgumentNullException(nameof(parent));
        this.ax = ax;
        this.ay = ay;
        this.aw = aw;
        this.ah = ah;
        this.x = x;
        this.y = y;
    }
}