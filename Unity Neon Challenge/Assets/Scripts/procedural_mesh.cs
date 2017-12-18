using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural_mesh : MonoBehaviour {
    // Use this for initialization
    public Material mat;
    public int width = 1;
    public int length = 1;
    public int height = 1;
    public int width_unit = 1;
    public int length_unit = 1;
    public int height_unit = 1;
    public void BuildObject() {
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.name = "building";
        mesh.Clear();

        Vector3[] vertices = new Vector3[(width * length + width * height + length * height) * 8];
        Vector2[] uvs = new Vector2[(width * length + width * height + length * height) * 8];
        int[] triangles = new int[(width * length + width * height + length * height) * 12];
        for (int i = 0; i < width; i++) {
            for (int j = 0; j < length; j++)
            {
                vertices[j + i * length] = new Vector3(i * width_unit, 0, j * length_unit);
                vertices[j + i * length + 2*width * length] = new Vector3((i + 1) * width_unit, 0, j * length_unit);
                vertices[j + i * length + width * length] = new Vector3(i * width_unit, 0, (j + 1) * length_unit);
                vertices[j + i * length + 3 * width * length] = new Vector3((i + 1) * width_unit, 0, (j + 1) * length_unit);

                vertices[j + i * length + 4 * width * length] = new Vector3(i * width_unit, height * height_unit, j * length_unit);
                vertices[j + i * length + 5 * width * length] = new Vector3((i + 1) * width_unit, height * height_unit, j * length_unit);
                vertices[j + i * length + 6 * width * length] = new Vector3(i * width_unit, height * height_unit, (j + 1) * length_unit);
                vertices[j + i * length + 7 * width * length] = new Vector3((i + 1) * width_unit, height * height_unit, (j + 1) * length_unit);

                uvs[j + i * length] = new Vector2(0, 0);
                uvs[j + i * length + width * length] = new Vector2(1, 0);
                uvs[j + i * length + 2 * width * length] = new Vector2(0, 1);
                uvs[j + i * length + 3 * width * length] = new Vector2(1, 1);
                uvs[j + i * length + 6 * width * length] = new Vector2(0, 0);
                uvs[j + i * length + 4 * width * length] = new Vector2(1, 0);
                uvs[j + i * length + 7 * width * length] = new Vector2(0, 1);
                uvs[j + i * length + 5 * width * length] = new Vector2(1, 1);

                triangles[6 * (j + i * length)] = j + i * length;
                triangles[6 * (j + i * length) + 1] = j + i * length + 2 * width * length;
                triangles[6 * (j + i * length) + 2] = j + i * length + width * length;
                triangles[6 * (j + i * length) + 3] = j + i * length + 2 * width * length;
                triangles[6 * (j + i * length) + 4] = j + i * length + 3 * width * length;
                triangles[6 * (j + i * length) + 5] = j + i * length + width * length;

                triangles[6 * (j + i * length + width * length)] = j + i * length + 4 * width * length;
                triangles[6 * (j + i * length + width * length) + 1] = j + i * length + 6 * width * length;
                triangles[6 * (j + i * length + width * length) + 2] = j + i * length + 5 * width * length;
                triangles[6 * (j + i * length + width * length) + 3] = j + i * length + 6 * width * length;
                triangles[6 * (j + i * length + width * length) + 4] = j + i * length + 7 * width * length;
                triangles[6 * (j + i * length + width * length) + 5] = j + i * length + 5 * width * length;
            }
        }

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                vertices[8 * width * length + 0 * width * height + j + i * height] = new Vector3(i * width_unit, j * height_unit, 0);
                vertices[8 * width * length + 1 * width * height + j + i * height] = new Vector3((i + 1) * width_unit, j * height_unit, 0);
                vertices[8 * width * length + 2 * width * height + j + i * height] = new Vector3(i * width_unit, (j + 1) * height_unit, 0);
                vertices[8 * width * length + 3 * width * height + j + i * height] = new Vector3((i + 1) * width_unit, (j + 1) * height_unit, 0);
                vertices[8 * width * length + 4 * width * height + j + i * height] = new Vector3(i * width_unit, j * height_unit, length * length_unit);
                vertices[8 * width * length + 6 * width * height + j + i * height] = new Vector3((i + 1) * width_unit, j * height_unit, length * length_unit);
                vertices[8 * width * length + 5 * width * height + j + i * height] = new Vector3(i * width_unit, (j + 1) * height_unit, length * length_unit);
                vertices[8 * width * length + 7 * width * height + j + i * height] = new Vector3((i + 1) * width_unit, (j + 1) * height_unit, length * length_unit);
                

                uvs[8 * width * length + 0 * width * height + j + i * height] = new Vector2(0, 0);
                uvs[8 * width * length + 1 * width * height + j + i * height] = new Vector2(1, 0);
                uvs[8 * width * length + 2 * width * height + j + i * height] = new Vector2(0, 1);
                uvs[8 * width * length + 3 * width * height + j + i * height] = new Vector2(1, 1);

                uvs[8 * width * length + 5 * width * height + j + i * height] = new Vector2(0, 0);
                uvs[8 * width * length + 7 * width * height + j + i * height] = new Vector2(1, 0);
                uvs[8 * width * length + 4 * width * height + j + i * height] = new Vector2(0, 1);
                uvs[8 * width * length + 6 * width * height + j + i * height] = new Vector2(1, 1);

                triangles[6 * (j + i * height + 2 * width * length)] = j + i * height + 0 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + 2 * width * length) + 1] = j + i * height + 2 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + 2 * width * length) + 2] = j + i * height + 1 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + 2 * width * length) + 3] = j + i * height + 2 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + 2 * width * length) + 4] = j + i * height + 3 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + 2 * width * length) + 5] = j + i * height + 1 * width * height + 8 * width * length;

                triangles[6 * (j + i * height + width * height + 2 * width * length)] = j + i * height + 4 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + width * height + 2 * width * length) + 1] = j + i * height + 6 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + width * height + 2 * width * length) + 2] = j + i * height + 5 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + width * height + 2 * width * length) + 3] = j + i * height + 6 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + width * height + 2 * width * length) + 4] = j + i * height + 7 * width * height + 8 * width * length;
                triangles[6 * (j + i * height + width * height + 2 * width * length) + 5] = j + i * height + 5 * width * height + 8 * width * length;
            }
        }

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < height; j++)
            {
                vertices[8 * width * length + 8 * width * height + j + i * height] = new Vector3(0, j * height_unit, i * length_unit);
                vertices[8 * width * length + 8 * width * height + 2 * length * height + j + i * height] = new Vector3(0, j * height_unit, (i + 1) * length_unit);
                vertices[8 * width * length + 8 * width * height + length * height + j + i * height] = new Vector3(0, (j + 1) * height_unit, i * length_unit);
                vertices[8 * width * length + 8 * width * height + 3 * length * height + j + i * height] = new Vector3(0, (j + 1) * height_unit, (i + 1) * length_unit);

                vertices[8 * width * length + 8 * width * height + 4 * length * height + j + i * height] = new Vector3(width * width_unit, j * height_unit, i * length_unit);
                vertices[8 * width * length + 8 * width * height + 5 * length * height + j + i * height] = new Vector3(width * width_unit, j * height_unit, (i + 1) * length_unit);
                vertices[8 * width * length + 8 * width * height + 6 * length * height + j + i * height] = new Vector3(width * width_unit, (j + 1) * height_unit, i * length_unit);
                vertices[8 * width * length + 8 * width * height + 7 * length * height + j + i * height] = new Vector3(width * width_unit, (j + 1) * height_unit, (i + 1) * length_unit);

                uvs[8 * width * length + 8 * width * height + 1 * length * height + j + i * height] = new Vector2(0, 0);
                uvs[8 * width * length + 8 * width * height + 3 * length * height + j + i * height] = new Vector2(1, 0);
                uvs[8 * width * length + 8 * width * height + 0 * length * height + j + i * height] = new Vector2(0, 1);
                uvs[8 * width * length + 8 * width * height + 2 * length * height + j + i * height] = new Vector2(1, 1);
                uvs[8 * width * length + 8 * width * height + 4 * length * height + j + i * height] = new Vector2(0, 0);
                uvs[8 * width * length + 8 * width * height + 5 * length * height + j + i * height] = new Vector2(1, 0);
                uvs[8 * width * length + 8 * width * height + 6 * length * height + j + i * height] = new Vector2(0, 1);
                uvs[8 * width * length + 8 * width * height + 7 * length * height + j + i * height] = new Vector2(1, 1);

                triangles[6 * (j + i * height + 2 * width * length + 2 * width * height)] = j + i * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + 2 * width * length + 2 * width * height) + 1] = j + i * height + 2 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + 2 * width * length + 2 * width * height) + 2] = j + i * height + length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + 2 * width * length + 2 * width * height) + 3] = j + i * height + 2 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + 2 * width * length + 2 * width * height) + 4] = j + i * height + 3 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + 2 * width * length + 2 * width * height) + 5] = j + i * height + length * height + 8 * width * length + 8 * width * height;

                triangles[6 * (j + i * height + length * height + 2 * width * height + 2 * width * length)] = j + i * height + 4 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + length * height + 2 * width * height + 2 * width * length) + 1] = j + i * height + 6 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + length * height + 2 * width * height + 2 * width * length) + 2] = j + i * height + 5 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + length * height + 2 * width * height + 2 * width * length) + 3] = j + i * height + 6 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + length * height + 2 * width * height + 2 * width * length) + 4] = j + i * height + 7 * length * height + 8 * width * length + 8 * width * height;
                triangles[6 * (j + i * height + length * height + 2 * width * height + 2 * width * length) + 5] = j + i * height + 5 * length * height + 8 * width * length + 8 * width * height;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        GetComponent<Renderer>().material = mat;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();
        filter.mesh = mesh;
        GetComponent<BoxCollider>().center = new Vector3(0.5f * width, 0.5f * height, 0.5f* length);
        GetComponent<BoxCollider>().size = new Vector3(width,height,length);
    }

}
