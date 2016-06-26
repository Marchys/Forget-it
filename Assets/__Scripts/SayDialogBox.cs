using UnityEngine;
using System.Collections;

public class SayDialogBox
{

    private float _width;

    public SayDialogBox(string id, Vector2 panelPosition, Vector2 position, float width, float height)
    {
        this.Height = height;
        this.Width = width;
        this.PanelPosition = panelPosition;
        this.Position = position;
        this.Id = id;
    }

    public Vector2 PanelPosition { get; private set; }
    public Vector2 Position { get; private set; }

    public string Id { get; private set; }

    public float Height { get; private set; }
    public float Width { get; private set; }
}

