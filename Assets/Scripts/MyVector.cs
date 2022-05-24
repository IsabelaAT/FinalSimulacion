using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class MyVector
{
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;

    }

    public MyVector(Vector2 other)
    {
        this.x = other.x;
        this.y = other.y;

    }

    public override string ToString()
    {
        return ("(" + x + "," + y + ")");
    }
    public MyVector Sumar(float x1, float y1)
    {
        float newX = x1;
        float newY = y1;

        return new MyVector(x1 + x, y1 + y);

    }
    public MyVector Sumar(MyVector b)
    {

        //return new MyVector(x+b.x,y+b.y);
        return this + b;

    }
    static public MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y);
    }
    public MyVector Restar(MyVector b)
    {
        //return new MyVector(x-b.x,y-b.y);
        return this - b;

    }
    static public MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y);
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(new Vector2(0, 0), new Vector2(x, y), color);
    }
    public void Draw(MyVector a, Color color)
    {
        Debug.DrawLine(new Vector2(0 + a.x, 0 + a.y), new Vector2(x + a.x, y + a.y), color);
    }
    public MyVector Multiplicar(float multi)
    {
        //return new MyVector(multi*x,multi*y);
        return this * multi;
    }
    static public MyVector operator *(MyVector a, float b)
    {
        return new MyVector(a.x * b, a.y * b);
    }
    static public MyVector operator *(float b, MyVector a)
    {
        return new MyVector(b * a.x, b * a.y);
    }
    //public static float Magnitud(MyVector d)
    //{
    //     float m = Mathf.Sqrt((d.x * d.x) + (d.y * d.y));
    //    return (m);
    //}
    public MyVector Dividir(float div)
    {
        return this / div;
        //return new MyVector(x/div, y/div);
    }
    static public MyVector operator /(MyVector a, float b)
    {
        return new MyVector(a.x / b, a.y / b);
    }
    static public MyVector operator /(float b, MyVector a)
    {
        return new MyVector(a.x / b, a.y / b);
    }
    public float Magnitud()
    {
        float m = Mathf.Sqrt((x * x) + (y * y));
        return (m);
    }
    public MyVector Normalizar()
    {
        float m = Mathf.Sqrt((x * x) + (y * y));
        if (m == 0)
            return new MyVector(0, 0);
        else
            return (new MyVector(x / m, y / m));
    }
    public float Punto(MyVector a)
    {

        float p = (a.x * x) + (a.y * y);
        return (p);

    }
    //public MyVector Lerp( MyVector b, float t)
    //{
    //    MyVector c = new MyVector(b.x - x, b.y - y);
    //    MyVector d = new MyVector(c.x*t,c.y*t);
    //    return new MyVector(x+d.x, y+d.y);
    // }
    public MyVector Lerp(MyVector b, float t)
    {
        //return Sumar(b.Restar(this).Multiplicar(t));
        return this + ((b - this) * t);
    }
    public static implicit operator Vector3(MyVector d)
    {
        return new Vector3(d.x, d.y);
    }
}