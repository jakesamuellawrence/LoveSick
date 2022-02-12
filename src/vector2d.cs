using System;

public class Vector2D {

    public float x;
    public float y;

    public Vector2D(float x, float y) {
        this.x = x;
        this.y = y;
    }

    public static Vector2D operator +(Vector2D a, Vector2D b) => a.add(b);
    public static Vector2D operator *(Vector2D a, float scalar) => a.times(scalar);

    public Vector2D add(Vector2D other) {
        return new Vector2D(this.x + other.x, this.y + other.y);
    }

    public Vector2D times(float scalar) {
        return new Vector2D(this.x * scalar, this.y * scalar);
    }

    public float magnitude() {
        return (float)Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2));
    }

    public void normalize() {
        float mag = this.magnitude();
        if (mag == 0) {
            mag = 1;
        }
        this.x = x / mag;
        this.y = y / mag;
    }

    public Vector2D normalized() {
        float mag = this.magnitude();
        if (mag == 0) {
            mag = 1;
        }
        return new Vector2D(this.x / mag, this.y / mag);
    }
}