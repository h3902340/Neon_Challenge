using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class procedural_mesh : MonoBehaviour
{
    // Use this for initialization
    public Material mat;
    public int width = 1;
    public int length = 1;
    public int height = 1;
    public float width_unit = 3;
    public float length_unit = 1;
    public float height_unit = 1;
    public GameObject[] prop_list;
    public void BuildObject()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mesh.name = "building";
        mesh.Clear();

        Vector3[] vertices = new Vector3[(width * length + width * height + length * height) * 8];
        Vector2[] uvs = new Vector2[(width * length + width * height + length * height) * 8];
        int[] triangles = new int[(width * length + width * height + length * height) * 12];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < length; j++)
            {
                vertices[j + i * length] = new Vector3(i * width_unit, 0, j * length_unit);
                vertices[j + i * length + 2 * width * length] = new Vector3((i + 1) * width_unit, 0, j * length_unit);
                vertices[j + i * length + width * length] = new Vector3(i * width_unit, 0, (j + 1) * length_unit);
                vertices[j + i * length + 3 * width * length] = new Vector3((i + 1) * width_unit, 0, (j + 1) * length_unit);

                vertices[j + i * length + 4 * width * length] = new Vector3(i * width_unit, height * height_unit, j * length_unit);
                vertices[j + i * length + 5 * width * length] = new Vector3((i + 1) * width_unit, height * height_unit, j * length_unit);
                vertices[j + i * length + 6 * width * length] = new Vector3(i * width_unit, height * height_unit, (j + 1) * length_unit);
                vertices[j + i * length + 7 * width * length] = new Vector3((i + 1) * width_unit, height * height_unit, (j + 1) * length_unit);

                uvs[j + i * length] = new Vector2(0, 0);
                uvs[j + i * length + 2 * width * length] = new Vector2(width_unit, 0);
                uvs[j + i * length + width * length] = new Vector2(0, length_unit);
                uvs[j + i * length + 3 * width * length] = new Vector2(width_unit, length_unit);
                uvs[j + i * length + 6 * width * length] = new Vector2(0, 0);
                uvs[j + i * length + 7 * width * length] = new Vector2(width_unit, 0);
                uvs[j + i * length + 4 * width * length] = new Vector2(0, length_unit);
                uvs[j + i * length + 5 * width * length] = new Vector2(width_unit, length_unit);

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
                uvs[8 * width * length + 1 * width * height + j + i * height] = new Vector2(width_unit, 0);
                uvs[8 * width * length + 2 * width * height + j + i * height] = new Vector2(0, height_unit);
                uvs[8 * width * length + 3 * width * height + j + i * height] = new Vector2(width_unit, height_unit);

                uvs[8 * width * length + 5 * width * height + j + i * height] = new Vector2(0, 0);
                uvs[8 * width * length + 7 * width * height + j + i * height] = new Vector2(width_unit, 0);
                uvs[8 * width * length + 4 * width * height + j + i * height] = new Vector2(0, height_unit);
                uvs[8 * width * length + 6 * width * height + j + i * height] = new Vector2(width_unit, height_unit);

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
                uvs[8 * width * length + 8 * width * height + 3 * length * height + j + i * height] = new Vector2(length_unit, 0);
                uvs[8 * width * length + 8 * width * height + 0 * length * height + j + i * height] = new Vector2(0, height_unit);
                uvs[8 * width * length + 8 * width * height + 2 * length * height + j + i * height] = new Vector2(length_unit, height_unit);
                uvs[8 * width * length + 8 * width * height + 4 * length * height + j + i * height] = new Vector2(0, 0);
                uvs[8 * width * length + 8 * width * height + 5 * length * height + j + i * height] = new Vector2(length_unit, 0);
                uvs[8 * width * length + 8 * width * height + 6 * length * height + j + i * height] = new Vector2(0, height_unit);
                uvs[8 * width * length + 8 * width * height + 7 * length * height + j + i * height] = new Vector2(length_unit, height_unit);

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
        Unwrapping.GenerateSecondaryUVSet(mesh);
        filter.mesh = mesh;
        GetComponent<BoxCollider>().center = new Vector3(0.5f * width * width_unit, 0.5f * height * height_unit, 0.5f * length * length_unit);
        GetComponent<BoxCollider>().size = new Vector3(width * width_unit, height * height_unit, length * length_unit);
    }

    public void PlaceProps()
    {
        // 0 is empty, 1 is long balcony
        int[] a = new int[(width * height + length * height) * 2];
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = Random.Range(0, 9);
        }
        for (int i = 1; i < a.Length - 1; i++)
        {
            if (a[i] == 1) // long balcony
            {
                if (a[i + 1] != 0)
                {
                    a[i + 1] = 0;
                }
                if (a[i - 1] != 0)
                {
                    a[i - 1] = 0;
                }
            }
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] == 1) // long balcony
            {
                if (i < width * height)
                {
                    if (i % width != 0 && i % width != width - 1)
                    {
                        Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .2f, -.38f), Quaternion.Euler(0, 180, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                        Instantiate(prop_list[3], transform.position + new Vector3((i % width) * width_unit + width_unit * (.5f-Random.Range(0,2)*.2f-.1f), (Mathf.Floor(i / width)) * height_unit + height_unit * .2f, -.69f), Quaternion.Euler(0, 180, 0), transform);
                    }
                }
                else if (i < 2 * width * height)
                {
                    if (i % width != 0 && i % width != width - 1)
                    {
                        Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .2f, .38f + length * length_unit), Quaternion.Euler(0, 0, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                        Instantiate(prop_list[3], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * (.5f-Random.Range(0,2)*.2f-.1f), (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .2f, .69f + length * length_unit), Quaternion.Euler(0, 0, 0), transform);
                    }
                }
                else if (i < 2 * width * height + height * length)
                {
                    if ((i - 2 * width * height) % length != 0 && (i - 2 * width * height) % length != length - 1)
                    {
                        Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-.38f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                        Instantiate(prop_list[3], transform.position + new Vector3(-.69f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height) % length) * length_unit + length_unit * (.5f - Random.Range(0, 2) * .2f - .1f)), Quaternion.Euler(0, -90, 0), transform);
                    }
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    if ((i - 2 * width * height) % length != 0 && (i - 2 * width * height) % length != length - 1)
                    {
                        Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(.38f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                        Instantiate(prop_list[3], transform.position + new Vector3(.69f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * (.5f - Random.Range(0, 2) * .2f - .1f)), Quaternion.Euler(0, 90, 0), transform);
                    }
                }
            }
            else if (a[i] == 2) // air conditioner
            {
                if (i < width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .5f, -.38f), Quaternion.Euler(0, 180, 0), transform);
                }
                else if (i < 2 * width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .5f, .38f + length * length_unit), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (i < 2 * width * height + height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-.38f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform);
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(.38f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform);
                }
            }
            else if (a[i] == 3) // balcony_short with door
            {
                if (i < width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .2f, -.38f), Quaternion.Euler(0, 180, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();

                    Instantiate(prop_list[3], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .2f, -.69f), Quaternion.Euler(0, 180, 0), transform);
                }
                else if (i < 2 * width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .2f, .38f + length * length_unit), Quaternion.Euler(0, 0, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                    Instantiate(prop_list[3], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .2f, .69f + length * length_unit), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (i < 2 * width * height + height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-.38f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                    Instantiate(prop_list[3], transform.position + new Vector3(-.69f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform);
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(.38f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform).transform.GetChild(0).GetComponent<random_towels>().Randomize_Towels();
                    Instantiate(prop_list[3], transform.position + new Vector3(.69f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform);
                }
            }
            else if (a[i] == 5) // jewelry_sign
            {
                if (i < width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .5f, -3.6f), Quaternion.Euler(0, -90, 0), transform);
                }
                else if (i < 2 * width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .5f, 3.6f + length * length_unit), Quaternion.Euler(0, 90, 0), transform);
                }
                else if (i < 2 * width * height + height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-3.6f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(3.6f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 180, 0), transform);
                }
            }
            else if (a[i] == 6) // window_short
            {
                if (i < width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .5f, -.38f), Quaternion.Euler(0, 180, 0), transform);
                }
                else if (i < 2 * width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .5f, .38f + length * length_unit), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (i < 2 * width * height + height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-.38f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform);
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(.38f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform);
                }
            }
            else if (a[i] == 7) // pao_tzu_sign
            {
                if (i < width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .2f, -.78f), Quaternion.Euler(0, 180, 0), transform);
                }
                else if (i < 2 * width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .2f, .78f + length * length_unit), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (i < 2 * width * height + height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-.78f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform);
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(.78f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .2f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform);
                }
            }
            else if (a[i] == 8) // double window
            {
                if (i < width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3((i % width) * width_unit + width_unit * .5f, (Mathf.Floor(i / width)) * height_unit + height_unit * .5f, -.38f), Quaternion.Euler(0, 180, 0), transform);
                }
                else if (i < 2 * width * height)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(((i - width * height) % width) * width_unit + width_unit * .5f, (Mathf.Floor((i - width * height) / width)) * height_unit + height_unit * .5f, .38f + length * length_unit), Quaternion.Euler(0, 0, 0), transform);
                }
                else if (i < 2 * width * height + height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(-.38f, (Mathf.Floor((i - 2 * width * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, -90, 0), transform);
                }
                else if (i < 2 * width * height + 2 * height * length)
                {
                    Instantiate(prop_list[a[i] - 1], transform.position + new Vector3(.38f + width * width_unit, (Mathf.Floor((i - 2 * width * height - length * height) / length)) * height_unit + height_unit * .5f, ((i - 2 * width * height - length * height) % length) * length_unit + length_unit * .5f), Quaternion.Euler(0, 90, 0), transform);
                }
            }
        }
    }

    public void RemoveProps()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
