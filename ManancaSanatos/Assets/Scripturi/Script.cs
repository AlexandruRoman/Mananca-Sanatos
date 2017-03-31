using UnityEngine;
using System.Collections;

public class Script : MonoBehaviour {

	public GameObject Cereale, Uleiuri, Fructe, Legume, Peste, Oaie, Porc, Vita, Miere, Lapte;

	public SpriteRenderer cereale, uleiuri, fructe, legume, peste, oaie, porc, vita, miere, lapte;

	public SpriteRenderer negru;

	public GameObject Sir_Cereale, Sir_Uleiuri, Sir_Fructe, Sir_Legume;

	int nr_Cereale, nr_Uleiuri, nr_Fructe, nr_Legume;



	Collider2D[] col;

	void Start () 
	{
		col = FindObjectsOfType(typeof(Collider2D)) as Collider2D[];
		nr_Fructe = nr_Cereale = nr_Legume = nr_Uleiuri = 1;
	}
	

	void Update () 
	{

		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{

			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			Collider2D hit = Physics2D.OverlapPoint(touchPos);

			if(hit.collider2D.name == "Cereale")
			{
				StartCoroutine( intrare(Cereale, cereale) );
			}

			if(hit.collider2D.name == "Uleiuri")
			{
				StartCoroutine( intrare(Uleiuri, uleiuri) );
			}

			if(hit.collider2D.name == "Fructe")
			{
				StartCoroutine( intrare(Fructe, fructe) );
			}

			if(hit.collider2D.name == "Legume")
			{
				StartCoroutine( intrare(Legume, legume) );
			}

			if(hit.collider2D.name == "Peste")
			{
				StartCoroutine( intrare(Peste, peste) );
			}

			if(hit.collider2D.name == "Oaie")
			{
				StartCoroutine( intrare(Oaie, oaie) );
			}

			if(hit.collider2D.name == "Porc")
			{
				StartCoroutine( intrare(Porc, porc) );
			}

			if(hit.collider2D.name == "Vita")
			{
				StartCoroutine( intrare(Vita, vita) );
			}

			if(hit.collider2D.name == "Miere")
			{
				StartCoroutine( intrare(Miere, miere) );
			}

			if(hit.collider2D.name == "Lapte")
			{
				StartCoroutine( intrare(Lapte, lapte) );
			}




			if(hit.collider2D.name == "Sus_Cereale")
			{
				avansare(ref nr_Cereale, 4, Sir_Cereale, -1);

			}

			if(hit.collider2D.name == "Jos_Cereale")
			{
				avansare(ref nr_Cereale, 4, Sir_Cereale, 1);

			}




			if(hit.collider2D.name == "Sus_Uleiuri")
			{
				avansare(ref nr_Uleiuri, 3, Sir_Uleiuri, -1);

			}
			
			if(hit.collider2D.name == "Jos_Uleiuri")
			{
				avansare(ref nr_Uleiuri, 3, Sir_Uleiuri, 1);

			}



			if(hit.collider2D.name == "Sus_Fructe")
			{
				avansare(ref nr_Fructe, 2, Sir_Fructe, -1);

			}


			if(hit.collider2D.name == "Jos_Fructe")
			{
				avansare(ref nr_Fructe, 2, Sir_Fructe, 1);

			}



			if(hit.collider2D.name == "Sus_Legume")
			{
				avansare(ref nr_Legume, 2, Sir_Legume, -1);

			}


			if(hit.collider2D.name == "Jos_Legume")
			{
				avansare(ref nr_Legume, 2, Sir_Legume, 1);

			}


		}


		if(Input.GetKey(KeyCode.Escape))
		{
			StartCoroutine( iesire(Cereale, cereale) );
			StartCoroutine( iesire(Uleiuri, uleiuri) );
			StartCoroutine( iesire(Fructe, fructe) );
			StartCoroutine( iesire(Legume, legume) );
			StartCoroutine( iesire(Peste, peste) );
			StartCoroutine( iesire(Oaie, oaie) );
			StartCoroutine( iesire(Porc, porc) );
			StartCoroutine( iesire(Vita, vita) );
			StartCoroutine( iesire(Miere, miere) );
			StartCoroutine( iesire(Lapte, lapte) );
		}






	









	}









	//Functii

	IEnumerator intrare(GameObject categ, SpriteRenderer info)
	{

		foreach(Collider2D c in col)
		{
			c.enabled = false;
		}

		iTween.MoveTo(gameObject, new Vector3(16.1f, 0, -10), 1.5f);

		categ.SetActive(true);

		yield return new WaitForSeconds(1.5f);

		Color cul = Color.white;
		cul.a = 0;

		for (int i=1;i<=100;i++)
		{
			cul.a += 0.01f;
			negru.color = cul;
			yield return new WaitForSeconds(0.01f);
		}

		cul.a = 0;
		
		for (int i=1;i<=100;i++)
		{
			cul.a += 0.01f;
			info.color = cul;
			yield return new WaitForSeconds(0.01f);
		}

		foreach(Collider2D c in col)
		{
			c.enabled = true;
		}

	}


	IEnumerator iesire(GameObject categ, SpriteRenderer info)
	{
		
		foreach(Collider2D c in col)
		{
			c.enabled = false;
		}
		
		iTween.MoveTo(gameObject, new Vector3(0, 0, -10), 1.5f);
		
		yield return new WaitForSeconds(1.5f);
		
		Color cul = Color.white;
		cul.a = 0;
		
		negru.color = info.color = cul;

		categ.SetActive(false);


		foreach(Collider2D c in col)
		{
			c.enabled = true;
		}
		
	}


	void avansare(ref int nr_x, int lim, GameObject sir, int i)
	{



		if(nr_x > 1 && i==-1)
		{
			nr_x--;
			iTween.MoveAdd(sir, new Vector3(0, -10, 0), 1);
		}

		if(nr_x < lim && i==1)
		{
			nr_x++;
			iTween.MoveAdd(sir, new Vector3(0, 10, 0), 1);
		}




	}























}
