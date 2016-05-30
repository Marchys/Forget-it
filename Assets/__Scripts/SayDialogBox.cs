using UnityEngine;
using System.Collections;

public class SayDialogBox
{

    private float _width;
    private float _height;

    public SayDialogBox(string id, Vector2 position, float width, float height)
    {
        this._height = height;
        this._width = width;
        this.Position = position;
        this.Id = id;
    }

    public Vector2 Position { get; private set; }

    public string Id { get; private set; }
}

