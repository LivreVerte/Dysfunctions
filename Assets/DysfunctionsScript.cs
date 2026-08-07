using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using KModkit;

public class DysfunctionsScript : MonoBehaviour {
	public KMAudio Audio;
	public KMBombInfo bomb;
	public TextMesh[] startingDisplay;
    public TextMesh[] queryDisplays;
    public TextMesh[] buttonDisplays;

    public Material[] neonOptions;
    public Renderer[] neon;
    public Color[] fontColor;

	static int moduleIdCounter = 1;
	int moduleID;
	private bool moduleSolved;

	private int factor1;
	private bool initialized = false;

    private int[] array1 = {0, 0, 0, 0, 0};
    private int[] array2 = {0, 0, 0, 0, 0};
    private int[] submission = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    private int arg = 1;
    private int current = 0;
    private int meta = 0;
    private int[] response = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    private bool reston = false;
    private int arguement = 0;
    private int[] second = {0, 0, 0, 0, 0};
    private int num11 = 0;
    private int num12 = 0;
    private int restriction;
    private bool rest1 = false;
    private bool rest2 = false;
    private int sign = 0;
    private int[] ans1 = {0, 0, 0, 0};
    private int[] ans2 = {0, 0, 0, 0};
    private bool stop = false;

	public KMSelectable[] buttons;

	void Start () {
        for(int i = 0; i <=2; i++){
            queryDisplays[i].text = "";
        }
		if(!initialized){
            moduleID = moduleIdCounter++;
		restriction = UnityEngine.Random.Range(2,36);
        arguement = UnityEngine.Random.Range(0, 2);
        current = UnityEngine.Random.Range(0, 36);
        meta = UnityEngine.Random.Range(0, 36);
		int divisible1 = UnityEngine.Random.Range(0,2);
        if(divisible1 == 0){
            ans1 = encode(UnityEngine.Random.Range(0,(int)1296/restriction)*restriction);
        } else {
            ans1 = encode(UnityEngine.Random.Range(0,1296));
        }
        int divisible2 = UnityEngine.Random.Range(0,2);
        if(divisible2 == 0){
            ans2 = encode(UnityEngine.Random.Range(0,(int)1296/restriction)*restriction);
        } else {
            ans2 = encode(UnityEngine.Random.Range(0,1296));
        }
		for(int i = 0; i <=2; i++){
            startingDisplay[i].text = "";
            queryDisplays[i].text = "";
        }
		for(int i = usefullen(ans1); i>=0; i--){
			startingDisplay[0].text = startingDisplay[0].text + ans1[i];
		}
        for(int i = usefullen(ans2); i>=0; i--){
			startingDisplay[2].text = startingDisplay[2].text + ans2[i];
		}
        sign = UnityEngine.Random.Range(0,2);
        if (sign == 0){
            startingDisplay[1].text = "-";
            Debug.LogFormat("[Dysfunctions #{0}] The digit restriction is -",moduleID);
        } else {
            startingDisplay[1].text = "+";
            Debug.LogFormat("[Dysfunctions #{0}] The digit restriction is +",moduleID);
        }
        startingDisplay[1].text = startingDisplay[1].text + ((int)restriction/6)+(restriction%6);
        //UnityEngine.Debug.Log("Restriction: "+restriction);
        //Debug.LogFormat("[Bamboozled Again #{0}] After {2} presses, the correct button to press is the {1} button", moduleID, location[answerKey[0][pressCount]], pressCount);
        Debug.LogFormat("[Dysfunctions #{0}] Divisible restriction: {1}{2}", moduleID,((int)restriction/6),restriction%6);
        //UnityEngine.Debug.Log("MetaFunction: " + ((int)(meta/6))+meta%6);
        Debug.LogFormat("[Dysfunctions #{0}] Metafunction: {1}{2}. ",moduleID,((int)(meta/6)),meta%6);
        if(arguement == 0){
            //UnityEngine.Debug.Log("Arguement 1");
            Debug.LogFormat("[Dysfunctions #{0}] The metafunction uses factor 1 as its second input.",moduleID);
        } else {
            //UnityEngine.Debug.Log("Arguement 2");
            Debug.LogFormat("[Dysfunctions #{0}] The metafunction uses factor 2 as its second input",moduleID);
        }
        //UnityEngine.Debug.Log("Current: " + ((int)(current/6))+(current%6));
        Debug.LogFormat("[Dysfunctions #{0}] Starting function: {1}{2}. ",moduleID,((int)(current/6)),current%6);
        //UnityEngine.Debug.Log("The first factor is " + ans1[3]+ans1[2]+ans1[1]+ans1[0]);
        Debug.LogFormat("[Dysfunctions #{0}] The first factor is {1}{2}{3}{4}. ",moduleID,ans1[3],ans1[2],ans1[1],ans1[0]);
        //UnityEngine.Debug.Log("The second factor is " + ans2[3]+ans2[2]+ans2[1]+ans2[0]);
        Debug.LogFormat("[Dysfunctions #{0}] The second factor is {1}{2}{3}{4}. ",moduleID,ans2[3],ans2[2],ans2[1],ans2[0]);
		initialized = true;
		}
	}
	void Awake () {
		foreach(KMSelectable button in buttons){
			KMSelectable pressedButton = button;
			button.OnInteract += delegate () { ButtonPress(pressedButton); return false;};
		}
	}
	void ButtonPress(KMSelectable button){
        if(moduleSolved || stop){
            return;
        }
        button.AddInteractionPunch();
        bool display = true;
        int pressed = 0;
        if(arg == 0){
            for(int i = 5; i>=0; i--){
                array1 = updateArray(array1, 0);
                array2 = updateArray(array2, 0);
            }
            for(int i = 0; i<=2; i++){
                queryDisplays[i].text = "";
            }
            arg = 1;
        }
		//UnityEngine.Debug.Log("The number you pressed is " + button.GetComponentInChildren<TextMesh>().text);
        if (button.GetComponentInChildren<TextMesh>().text == "0"){
            pressed = 0;
            GetComponent<KMAudio>().PlaySoundAtTransform("Dys0", transform);
        } else if (button.GetComponentInChildren<TextMesh>().text == "1"){
            pressed = 1;
            GetComponent<KMAudio>().PlaySoundAtTransform("Dys1", transform);
        } else if (button.GetComponentInChildren<TextMesh>().text == "2"){
            pressed = 2;
            GetComponent<KMAudio>().PlaySoundAtTransform("Dys2", transform);
        } else if (button.GetComponentInChildren<TextMesh>().text == "3"){
            pressed = 3;
            GetComponent<KMAudio>().PlaySoundAtTransform("Dys3", transform);
        } else if (button.GetComponentInChildren<TextMesh>().text == "4"){
            pressed = 4;
            GetComponent<KMAudio>().PlaySoundAtTransform("Dys4", transform);
        } else if (button.GetComponentInChildren<TextMesh>().text == "5"){
            pressed = 5;
            GetComponent<KMAudio>().PlaySoundAtTransform("Dys5", transform);
        } else if (button.GetComponentInChildren<TextMesh>().text == ","){
            if(arg == 1){
                queryDisplays[0].text = queryDisplays[2].text;
                queryDisplays[2].text = "";
                arg = 2;
                for(int i = usefullen(array1); i >= 0; i--){
                    if(array1[i] == 0){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys0", transform);
                    } else if (array1[i] == 1){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys1", transform);
                    } else if (array1[i] == 2){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys2", transform);
                    } else if (array1[i] == 3){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys3", transform);
                    } else if (array1[i] == 4){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys4", transform);
                    } else if (array1[i] == 5){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys5", transform);
                    }
                }
            }
            display = false;
        } else if (button.GetComponentInChildren<TextMesh>().text == "Q"){
            //GetComponent<KMBombModule>().HandleStrike();
            if(arg == 2){
                queryDisplays[1].text = queryDisplays[2].text;
                response = funSorting(current, array1, array2);
                //UnityEngine.Debug.Log("You queried: " + array1[4]+array1[3]+array1[2]+array1[1]+array1[0]+" and "+ array2[4]+array2[3]+array2[2]+array2[1]+array2[0]);
                Debug.LogFormat("[Dysfunctions #{0}] You queried: {1}{2}{3}{4}{5} and {6}{7}{8}{9}{10}. ",moduleID,array1[4],array1[3],array1[2],array1[1],array1[0],array2[4],array2[3],array2[2],array2[1],array2[0]);
                queryDisplays[2].text = "";
                if(reston){
                //UnityEngine.Debug.Log("Checking restrictions");
                Debug.LogFormat("[Dysfunctions #{0}] Checking restrictions: ",moduleID);
                if(array1[2] != num11*2 && array1[2] != (num11*2+1)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 1 invalid by +-.",moduleID);
                    //UnityEngine.Debug.Log("Input 1 invalid by +-");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                if(array2[2] != num12*2 && array2[2] != (num12*2+1)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 2 invalid by +-.",moduleID);
                    //UnityEngine.Debug.Log("Input 2 invalid by +-");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                if(rest1 == ((int)decode(array1)%restriction == 0)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 1 invalid by factors.",moduleID);
                    //UnityEngine.Debug.Log("Input 1 invalid by Factors");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                if(rest2 == ((int)decode(array2)%restriction ==0)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 2 invalid by factors.",moduleID);
                    //UnityEngine.Debug.Log("Input 2 invalid by Factors");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                }
                Debug.LogFormat("[Dysfunctions #{0}] Conditions passed. ",moduleID);
                for(int i = usefullen(array2); i >= 0; i--){
                    if(array2[i] == 0){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys0", transform);
                    } else if (array2[i] == 1){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys1", transform);
                    } else if (array2[i] == 2){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys2", transform);
                    } else if (array2[i] == 3){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys3", transform);
                    } else if (array2[i] == 4){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys4", transform);
                    } else if (array2[i] == 5){
                        GetComponent<KMAudio>().PlaySoundAtTransform("Dys5", transform);
                    }
                }
                if (arguement == 0){
                    second = array1;
                } else {
                    second = array2;
                }
                current = ((int)decode(funSorting(meta, response, second))+current)%36;
                for(int i = usefullen(response); i>=0; i--){
		        	queryDisplays[2].text = queryDisplays[2].text + response[i];
		        }
                Debug.LogFormat("[Dysfunctions #{0}] Query Result: {1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",moduleID,response[9],response[8],response[7],response[6],response[5],response[4],response[3],response[2],response[1],response[0]);
                //unityengine.debug.Log("New Function: " + ((int)(current/6))+(current%6));
                Debug.LogFormat("[Dysfunctions #{0}] New Function: {1}{2}. ", moduleID, ((int)(current/6)),current%6);
                rest1 = (int)decode(array1)%restriction == 0;
                rest2 = (int)decode(array2)%restriction == 0;
                num11 = (int)(array1[2]/2);
                num12 = (int)(array2[2]/2);
                if (sign == 0){
                    num11 = (num11-1)%3;
                    num12 = (num12-1)%3;
                    if (num11 == -1){
                     num11 = 2;
                    }
                if (num12 == -1){
                        num12 = 2;
                    }
                } else {
                    num11 = (num11+1)%3;
                    num12 = (num12+1)%3;
                }
            reston = true;
            arg = 0;
            }
            display = false;
        } else if (button.GetComponentInChildren<TextMesh>().text == "S"){
            display = false;
            if(arg == 1 || arg == 2){
                //UnityEngine.Debug.Log("Checking restrictions");
                if (reston){
                    Debug.LogFormat("[Dysfunctions #{0}] Checking restrictions: ",moduleID);
                if(ans1[2] != num11*2 && ans1[2] != (num11*2+1)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 1 invalid by +-.",moduleID);
                    //UnityEngine.Debug.Log("Input 1 invalid by +-");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                if(ans2[2] != num12*2 && ans2[2] != (num12*2+1)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 2 invalid by +-.",moduleID);
                    //UnityEngine.Debug.Log("Input 2 invalid by +-");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                if(rest1 == ((int)decode(ans1)%restriction == 0)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 1 invalid by factors.",moduleID);
                    //UnityEngine.Debug.Log("Input 1 invalid by Factors");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                if(rest2 == ((int)decode(ans2)%restriction ==0)){
                    Debug.LogFormat("[Dysfunctions #{0}] Input 2 invalid by factors.",moduleID);
                    //UnityEngine.Debug.Log("Input 2 invalid by Factors");
                    reston = false;
                    GetComponent<KMBombModule>().HandleStrike();
                    arg = 0;
                    GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
                    reston = false;
                    return;
                }
                }
                //unityengine.debug.Log("Submission Detected. Restrictions are either satisfied or do not apply. Proceed");
                Debug.LogFormat("[Dysfunctions #{0}] Submission Detected. Restrictions are either satisfied or do not apply. Proceed. ",moduleID);
                queryDisplays[0].text = startingDisplay[0].text;
                queryDisplays[1].text = startingDisplay[2].text;
                queryDisplays[2].text = "";
                arg = 3;
            } else if(arg == 3){
                GetComponent<KMAudio>().PlaySoundAtTransform("DysSus", transform);
                StartCoroutine(Delay(2));
            }
        }
        if (display){
            if (arg == 1){
                array1 = updateArray(array1, pressed);
                queryDisplays[2].text = "";
                for(int i = usefullen(array1); i>=0; i--){
		        	queryDisplays[2].text = queryDisplays[2].text + array1[i];
		        }
            } else if (arg == 2){
                array2 = updateArray(array2, pressed);
                queryDisplays[2].text = "";
                for(int i = usefullen(array2); i>=0; i--){
		        	queryDisplays[2].text = queryDisplays[2].text + array2[i];
		        }
            } else if (arg == 3){
                submission = updateArray(submission, pressed);
                queryDisplays[2].text = "";
                for(int i = usefullen(submission); i>=0; i--){
		        	queryDisplays[2].text = queryDisplays[2].text + submission[i];
		        }
            }
        } 
	}
    IEnumerator Delay(int i){
        foreach(Renderer tube in neon){
            tube.material = neonOptions[1];
        }
        foreach(TextMesh text in buttonDisplays){
            text.color = fontColor[1];
        }
        foreach(TextMesh text in queryDisplays){
                text.color = fontColor[1];
            }
            foreach(TextMesh text in startingDisplay){
                text.color = fontColor[1];
            }
        stop = true;
        yield return new WaitForSeconds(2);
        bool leave = true;
        int answer = (int)(decode(funSorting(current, ans1, ans2)))+36*meta+current;
        int[] logging = encode(answer);
        //unityengine.debug.Log("The final answer is: " + logging[9]+logging[8]+logging[7]+logging[6]+logging[5]+logging[4]+logging[3]+logging[2]+logging[1]+logging[0]);
        Debug.LogFormat("[Dysfunctions #{0}] The final answer is: {1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",moduleID,logging[9],logging[8],logging[7],logging[6],logging[5],logging[4],logging[3],logging[2],logging[1],logging[0]);
        //UnityEngine.Debug.Log("You Submitted: " + submission[9]+ submission[8]+ submission[7]+ submission[6]+ submission[5]+ submission[4]+ submission[3]+ submission[2]+ submission[1]+ submission[0]);
        Debug.LogFormat("[Dysfunctions #{0}] Your answer is: {1}{2}{3}{4}{5}{6}{7}{8}{9}{10}",moduleID,submission[9],submission[8],submission[7],submission[6],submission[5],submission[4],submission[3],submission[2],submission[1],submission[0]);
        if((int)(decode(submission)) == answer){
            leave = true;
        } else {
            leave = false;
        }
        if(leave){
            foreach(TextMesh text in queryDisplays){
                text.text = "";
                text.color = fontColor[0];
            }
            foreach(TextMesh text in startingDisplay){
                text.text = "";
                text.color = fontColor[0];
            }
            Debug.LogFormat("[Dysfunctions #{0}] Submission Correct. You Win!",moduleID);
            GetComponent<KMAudio>().PlaySoundAtTransform("Dysfunctional Mess", transform);
            buttonDisplays[0].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[0].color = fontColor[1];
            buttonDisplays[1].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[1].color = fontColor[1];
            buttonDisplays[2].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[2].color = fontColor[1];
            buttonDisplays[3].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[3].color = fontColor[1];
            buttonDisplays[4].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[4].color = fontColor[1];
            buttonDisplays[5].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[5].color = fontColor[1];
            buttonDisplays[8].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[8].color = fontColor[1];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[8].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[7].color = fontColor[0];
            buttonDisplays[8].color = fontColor[1];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[6].color = fontColor[0];
            buttonDisplays[7].color = fontColor[1];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[6].color = fontColor[1];
            buttonDisplays[7].color = fontColor[0];
            yield return new WaitForSeconds(1f);
            buttonDisplays[7].color = fontColor[1];
            buttonDisplays[1].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[1].color = fontColor[1];
            buttonDisplays[4].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[4].color = fontColor[1];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[4].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[4].color = fontColor[1];
            buttonDisplays[5].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[5].color = fontColor[1];
            buttonDisplays[4].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[4].color = fontColor[1];
            buttonDisplays[3].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[3].color = fontColor[1];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[3].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[3].color = fontColor[1];
            buttonDisplays[4].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[4].color = fontColor[1];
            buttonDisplays[3].color = fontColor[0];
            yield return new WaitForSeconds(0.5f);
            buttonDisplays[3].color = fontColor[1];
            buttonDisplays[2].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[2].color = fontColor[1];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[2].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[2].color = fontColor[1];
            buttonDisplays[1].color = fontColor[0];
            yield return new WaitForSeconds(0.25f);
            buttonDisplays[1].color = fontColor[1];
            buttonDisplays[0].color = fontColor[0];
            startingDisplay[1].text = "G";
            yield return new WaitForSeconds(0.5f);
            startingDisplay[1].text = "GG";
            moduleSolved = true;
            foreach(TextMesh text in buttonDisplays){
                text.color = fontColor[3];
            }
            foreach(TextMesh text in queryDisplays){
                text.color = fontColor[3];
            }
            foreach(TextMesh text in startingDisplay){
                text.color = fontColor[3];
            }
            GetComponent<KMBombModule>().HandlePass();
            foreach(Renderer tube in neon){
                tube.material = neonOptions[3];
            }
            queryDisplays[2].text = "You Win";
        } else {
            GetComponent<KMBombModule>().HandleStrike();
            GetComponent<KMAudio>().PlaySoundAtTransform("DysTrike", transform);
            Debug.LogFormat("[Dysfunctions #{0}] Submission incorrect. Keep going. ",moduleID);
            foreach(Renderer tube in neon){
                tube.material = neonOptions[2];
            }
            foreach(TextMesh text in buttonDisplays){
                text.color = fontColor[2];
            }
            foreach(TextMesh text in queryDisplays){
                text.color = fontColor[2];
            }
            foreach(TextMesh text in startingDisplay){
                text.color = fontColor[2];
            }
            yield return new WaitForSeconds(1);
            arg = 0;
            stop = false;
            reston = false;
            foreach(Renderer tube in neon){
                tube.material = neonOptions[0];
            }
            foreach(TextMesh text in buttonDisplays){
                text.color = fontColor[0];
            }
            foreach(TextMesh text in queryDisplays){
                text.color = fontColor[0];
            }
            foreach(TextMesh text in startingDisplay){
                text.color = fontColor[0];
            }
            for(int o = 10; o >= 0; o--){
                submission = updateArray(submission, 0);
            }
            Start();
        }
    }
    public static int[] updateArray(int[] arr, int novel){
        for(int n = arr.Length-1; n > 0; n--){
            arr[n]= arr[n-1];
        }
        arr[0]= novel;
        return arr;
    }
	public static int[] encode(long result){
        int[] array = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        while(true){
            if(result <= 0){
                break;
            }
            int n=0;
            while((int)Math.Pow(6, n+1)<=result){
                n++;
            }
            if (n <= array.Length-1){
                array[n] = array[n]+1;
            }
            result = result-(int)Math.Pow(6, n);
        }
        return array;
    }
	public static int usefullen(int[] array){
        int n = array.Length-1;
        while (true){
        if(array[n] == 0){
            if(n == 0){
                break;
            }
            n--;
        } else {
            break;
        }
        }
        if (n == -1){
            n = 0;
        }
        return n;
    }
    public static long decode(int[] arr){
        int result = 0;
        for (int n = arr.Length-1; n>=0; n--){
            result = result+arr[n]*(int)Math.Pow(6,n);
        }
        return result;
    }
    public static int[] base36(int[] num){
        int len = usefullen(num);
        int[] result = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        if (len % 2 == 0){
            result = updateArray(result, num[len]);
            len--;
        }
        while (len != -1){
            int novel;
            novel = num[len]*6 + num[len-1];
            result = updateArray(result, novel);
            len -= 2;
        }
        return result;
    }
    public static int[] decode36(int[] num){
        int len = usefullen(num);
        int[] result = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        for(int n = len; n >= 0; n--){
            result[2*n+1] = (int)(num[n]/6);
            result[2*n] = num[n]%6;
        }
        return result;
    }
    public static int[] fun00(int[] num1, int[] num2){
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int[] output = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int temp = 0;
        for(int i = 0; i<(len1+1); i++){
            for(int j = 0; j<(len2+1); j++){
                if(num1[i]<num2[j]){
                    temp = num1[i];
                } else{
                    temp = num2[j];
                }
                if(temp>output[i+j]){
                    output[i+j] = temp;
                }
            }
        }
        return output;
    }
    public static int[] fun01(int[] num1, int[] num2){
        int a = (int)(decode(num1)%5);
        int b = (int)(decode(num2)%5);
        if (a == 0){
            a = 5;
        }
        if ((int)decode(num1) == 0){
            a = 0;
        }
        if (b == 0){
            b = 5;
        }
        if ((int)decode(num2) == 0){
            b = 0;
        }
        return encode(a+b);
    }
    public static int[] fun02(int[] num1, int[] num2){
        int[] output = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        for(int n = len1; n>=0; n--){
            if(num1[n] == 0 || num1[n] == 2 || num1[n] == 4){
                output = updateArray(output, num1[n]);
            }
        }
        for(int n = len2; n>=0; n--){
            if(num2[n] == 0 || num2[n] == 2 || num2[n] == 4){
                output = updateArray(output, num2[n]);
            }
        }
        for(int n = len1; n>=0; n--){
            if(num1[n] == 1 || num1[n] == 3 || num1[n] == 5){
                output = updateArray(output, num1[n]);
            }
        }
        for(int n = len2; n>=0; n--){
            if(num2[n] == 1 || num2[n] == 3 || num2[n] == 5){
                output = updateArray(output, num2[n]);
            }
        }
        return output;
    }
    public static int[] fun03(int[] num1, int[] num2){
        int[] result = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        result = encode((int)decode(num1)^(int)decode(num2));
        return result;
    }
    public static int[] fun04(int[] num1, int[] num2){
        return encode((int)Math.Sqrt(((int)(Math.Pow(decode(num1), 2))+(int)(Math.Pow(decode(num2), 2))))%60466176);
    }
    public static int[] fun05(int[] num1, int[] num2){
        return encode((int)decode(num1)+(int)decode(num2));
    }
    public static int[] fun10(int[] num1, int[] num2){
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int result = 0;
        int count; 
        for (int n = 0; n<=5; n++){
            count = 0;
            for(int o = len1; o>=0; o--){
                if(num1[o] == n){
                    count++;
                }
            }
            for(int o = len2; o>=0; o--){
                if(num2[o] == n){
                    count++;
                }
            }
            if (count == 0){
                result++;
            }
        }
        return encode(result);
    }
    public static int[] fun11(int[] num1, int[] num2){
        int[] high = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] low = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        for(int n = len1; n>=0; n--){
            if(num1[n] == 3 || num1[n] == 4 || num1[n] == 5){
                high = updateArray(high, num1[n]);
            }
        }
        for(int n = len2; n>=0; n--){
            if(num2[n] == 3 || num2[n] == 4 || num2[n] == 5){
                high = updateArray(high, num2[n]);
            }
        }
        for(int n = len1; n>=0; n--){
            if(num1[n] == 0 || num1[n] == 1 || num1[n] == 2){
                low = updateArray(low, num1[n]);
            }
        }
        for(int n = len2; n>=0; n--){
            if(num2[n] == 0 || num2[n] == 1 || num2[n] == 2){
                low = updateArray(low, num2[n]);
            }
        }
        return encode(Math.Abs(decode(high)-decode(low)));
    }
    public static int[] fun12(int[] num1, int[] num2){
        int result = (int)(decode(num1)%60466176)+(int)decode(num2);
        int[] array = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        while(true){
            if(result <= 0){
                break;
            }
            int n=0;
            while((int)Math.Pow(5, n+1)<=result){
                n++;
            }
            array[n] = array[n]+1;
            result = result-(int)Math.Pow(5, n);
        }
        return array;
    }
    public static int[] fun13(int[] num1, int[] num2){
        return encode(decode(num1)*decode(num2));
    }
    public static int[] fun14(int[] num1, int[] num2){
        return encode(num1[0]*(int)decode(num2));
    }
    public static int[] fun15(int[] num1, int[] num2){
        int[] output = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int n1 = len1;
        int n2 = 0;
        while(n1 != -1 && n2 != (len2+1)){
            output = updateArray(output, Math.Abs(num1[n1]-num2[n2]));
            n2++;
            n1--;
        }
        if (n1 == -1 && n2 == (len2+1)){
        } else if (n1 <= 0 && n2 >=(len2)){
            output = updateArray(output,0);
        }else if(n1 == -1){
            n1 = len2;
            while(n1>=n2){
                output = updateArray(output, Math.Abs(num2[n1]-num2[n2]));
                n1--;
                n2++;
            }
        } else if (n2 == len2+1){
            n2 = 0;
            while(n2<=n1){
                output = updateArray(output, Math.Abs(num1[n1]-num1[n2]));
                n2++;
                n1--;
            }
        }
        return output;
    }
    public static int[] fun20(int[] num1, int[] num2){
        return encode((int)Math.Abs((int)Math.Pow((int)decode(num1)%216, 3)-(int)Math.Pow((int)decode(num2)%216,3) ));
    }
    public static int[] fun21(int[] num1, int[] num2){
        int a = (int)decode(num1)%18;
        int b = (int)decode(num2)%18;
        long c = 1;
        long d = 1;
        long e = 1;
        int f = 0;
        if (b>a){
            f = b;
            b = a;
            a = f;
        }
        for (int i = 1; i<=a; i++){
            c = c*i;
        } 
        for (int i = 1; i<=b; i++){
            d = d*i;
        }
        for (int i = 1; i <= (a-b); i++){
            e = e*i;
        }
        long g = (c)/(d*e);
        return encode(g);
    }
    public static int[] fun22(int[] num1, int[] num2){
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int result =  0;
        for(int n = 0; n<=len1; n++){
            if(num1[n] == 0){
                result +=8;
            } else if (num1[n] == 1){
                result +=2;
            } else if (num1[n] == 2){
                result +=6;
            } else if (num1[n] == 3){
                result += 6;
            } else if (num1[n] == 4){
                result += 5;
            } else if (num1[n] == 5){
                result += 6;
            }
        }
        for(int n = 0; n<=len2; n++){
            if(num2[n] == 0){
                result +=8;
            } else if (num2[n] == 1){
                result +=3;
            } else if (num2[n] == 2){
                result +=6;
            } else if (num2[n] == 3){
                result += 6;
            } else if (num2[n] == 4){
                result += 5;
            } else if (num2[n] == 5){
                result += 6;
            }
        }
        return (encode(result));
    }
    public static int[] fun23(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        int f = 0;
        if (b>a){
            f = b;
            b = a;
            a = f;
        }
        while(b != 0){
            f = a;
            a = b;
            b = f%a;
        }
        return encode(a);
    }
    public static int[] fun24(int[] num1, int[] num2){
        if ((decode(num1) == 0) || (decode(num2) == 0)){
            return encode(0);
        }
        return encode(((int)decode(num1)*(int)decode(num2))/(int)decode(fun23(num1,num2)));
    }
    public static int[] fun25(int[] num1, int[] num2){
        return encode((int)((int)decode(num1)+(int)decode(num2))/2);
    }
    public static int[] fun30(int[] num1, int[] num2){
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int n = len1;
        int[] out1 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int[] out2 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        while (true) {
            int i = num1[n];
            int j = 1;
            n--;
            if (n != -1){
                while(num1[n] == i){
                    n--;
                    j = (j+1)%6;
                    if (n == -1){
                        break;
                    } 
                }
            } 
            out1 = updateArray(out1, j);
            out1 = updateArray(out1, i);
            if(n == -1){
                break;
            }
        }
        n = len2;
        while (true) {
            int i = num2[n];
            int j = 1;
            n--;
            if (n != -1){
                while(num2[n] == i){
                    n--;
                    j = (j+1)%6;
                    if (n == -1){
                        break;
                    }
                }
            }
            out2 = updateArray(out2, j);
            out2 = updateArray(out2, i);
            if(n == -1){
                break;
            }
        }
        return (encode((int)decode(out1)+(int)decode(out2)));
    }
    public static int[] fun31(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        int f = 0;
        if (b>a){
            f = b;
            b = a;
            a = f;
        }
        if(b == 0){
            return encode(a);
        }
        return encode(a%b);
    }
    public static int[] fun32(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        return encode(Math.Abs(a*(a+1)/2-b*(b+1)/2));
    }
    public static int[] fun33(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        int f = 0;
        if (b>a){
            f = b;
            b = a;
            a = f;
        }
        if (b == 0){
            return encode(a);
        }
        return encode(a/b);
    }
    public static int[] fun34(int[] num1, int[] num2){
        int[] output = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int n = num1.Length-1;
        while (n >= 0){
            if(n<=(num2.Length-1)){
                output = updateArray(output, (int)Math.Abs(num1[n]-num2[n]));
            }
            n--;
        }
        return output;
    }
    public static int[] fun35(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        int f = 0;
        if (b>a){
            f = b;
            b = a;
            a = f;
        }
        return (encode((int)Math.Abs(2*b-a)));
    }
    public static int[] fun40(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        int c = (a+b)%5;
        if (c == 0){
            c = 5;
        }
        if (a+b == 0){
            c = 0;
        }
        return (encode (c));
    }
    public static int[] fun41(int[] num1, int[] num2){
        float a = (int)decode(num1);
        float b = (int)decode(num2);
        if(a == 0){
            a = 1;
        }
        if(b == 0){
            b = 1;
        }
        float c = 1/((1/a)+(1/b));
        return encode((int)c);
    }
    public static int[] fun42(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        if (a == 0){
            return encode((long)(b*b));
        }
        return encode((int)((a-b)*(a-b)/a));
    }
    public static int[] fun43(int[] num1, int[] num2){
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int[] sorted = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        for (int i = 0; i <= 5; i++){
        
            for(int n = len1; n>=0; n--){
                if(num1[n] == i){
                    sorted = updateArray(sorted, i);
                }
            }
            for(int n = len2; n>=0; n--){
                if(num2[n] == i){
                    sorted = updateArray(sorted, i);
                }
            }
        }
        return sorted;
    }
    public static int[] fun44(int[] num1, int[] num2){
        int a = (int)decode(num1);
        int b = (int)decode(num2);
        if (a == 0){
            a = 1;
        }
        if (b == 0){
            b = 1;
        }
        int result = 0;
        while (a % 2 == 0) {
            a /= 2;
            result += 2;
        }
        for (int i = 3; a != 1; i += 2) {
            while (a % i == 0) {
                result += i;
                a /= i;
            }
        }
        while (b % 2 == 0) {
            b /= 2;
            result += 2;
        }
        for (int i = 3; b != 1; i += 2) {
            while (b % i == 0) {
                result += i;
                b /= i;
            }
        }
        return (encode(result));
    }
    public static int[] fun45(int[] num1, int[] num2){
        return (encode((int)(Math.Abs((int)decode(num1)-(int)decode(num2))/2)));
    }
    public static int[] fun50(int[] num1, int[] num2){
        int[] array1 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int a = (int)decode(num1);
        int[] array2 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int b = (int)decode(num2);
        while(true){
            if(a <= 0){
                break;
            }
            int n=0;
            while((int)Math.Pow(3, n+1)<=a){
                n++;
            }
            array1[n] = array1[n]+1;
            a = a-(int)Math.Pow(3, n);
        }
        while(true){
            if(b <= 0){
                break;
            }
            int n=0;
            while((int)Math.Pow(3, n+1)<=b){
                n++;
            }
            array2[n] = array2[n]+1;
            b = b-(int)Math.Pow(3, n);
        }
        int p = usefullen(array1);
        int o = usefullen(array2);
        int result = 0;
        while (p >= 0){
            if(array1[p] == 2){
                result++;
            }
            p--;
        }
        while (o >= 0){
            if(array2[o] == 2){
                result++;
            }
            o--;
        }
        return encode(result);
    }
    public static int[] fun51(int[] num1, int[] num2){
        int[] result = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int len2 = usefullen(num2);
        int n = num1.Length-1;
        while (n != -1){
            if(n > len2){
                result[n] = num1[n];
            } else {
            if (num1[n] > num2[n]){
                result[n] = num1[n];
            } else {
                result[n] = num2[n];
            }
            }
            n--;
        }
        return result;
    }
    public static int[] fun52(int[] num1, int[] num2){
        int len1 = usefullen(num1);
        int len2 = usefullen(num2);
        int i = len1;
        int j = len2;
        int result = 0;
        while(i >= 0){
            result += num1[i];
            i--;
        }
        while(j >= 0){
            result += num2[j];
            j--;
        }
        return encode(result);
    }
    public static int[] fun53(int[] num1, int[] num2){
        int[] array1 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int a = (int)decode(num1);
        int[] array2 = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int b = (int)decode(num2);
        int n = 0;
        while(true){
            if(a <= 0){
                break;
            }
            n=0;
            while((int)Math.Pow(2, n+1)<=a){
                n++;
            }
            array1[n] = array1[n]+1;
            a = a-(int)Math.Pow(2, n);
        }
        while(true){
            if(b <= 0){
                break;
            }
            n=0;
            while((int)Math.Pow(2, n+1)<=b){
                n++;
            }
            array2[n] = array2[n]+1;
            b = b-(int)Math.Pow(2, n);
        }
        n = usefullen(array1);
        int o = usefullen(array2);
        int result = 0;
        while (n >= 0){
            if(array1[n] == 0){
                result++;
            }
            n--;
        }
        while (o >= 0){
            if(array2[o] == 0){
                result++;
            }
            o--;
        }
        return encode(result);
    }
    public static int[] fun54(int[] num1, int[] num2){
        return(fun52(base36(num1), base36(num2)));
    }
    public static int[] fun55(int[] num1, int[] num2){
        int a = (int)decode(num1)%35;
        int b = (int)decode(num2)%35;
        if (a == 0){
            a = 35;
        }
        if ((int)decode(num1) == 0){
            a = 0;
        }
        if (b == 0){
            b = 35;
        }
        if ((int)decode(num2) == 0){
            b = 0;
        }
        return encode(a+b);
    }
    public static int[] funSorting(int current, int[] array1, int[] array2){
        int[] output = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        switch (current){
            case 0: output = fun00(array1, array2);
            break;
            case 1: output = fun01(array1, array2);
            break;
            case 2: output = fun02(array1, array2);
            break;
            case 3: output = fun03(array1, array2);
            break;
            case 4: output = fun04(array1, array2);
            break;
            case 5: output = fun05(array1, array2);
            break;
            case 6: output = fun10(array1, array2);
            break;
            case 7: output = fun11(array1, array2);
            break;
            case 8: output = fun12(array1, array2);
            break;
            case 9: output = fun13(array1, array2);
            break;
            case 10: output = fun14(array1, array2);
            break;
            case 11: output = fun15(array1, array2);
            break;
            case 12: output = fun20(array1, array2);
            break;
            case 13: output = fun21(array1, array2);
            break;
            case 14: output = fun22(array1, array2);
            break;
            case 15: output = fun23(array1, array2);
            break;
            case 16: output = fun24(array1, array2);
            break;
            case 17: output = fun25(array1, array2);
            break;
            case 18: output = fun30(array1, array2);
            break;
            case 19: output = fun31(array1, array2);
            break;
            case 20: output = fun32(array1, array2);
            break;
            case 21: output = fun33(array1, array2);
            break;
            case 22: output = fun34(array1, array2);
            break;
            case 23: output = fun35(array1, array2);
            break;
            case 24: output = fun40(array1, array2);
            break;
            case 25: output = fun41(array1, array2);
            break;
            case 26: output = fun42(array1, array2);
            break;
            case 27: output = fun43(array1, array2);
            break;
            case 28: output = fun44(array1, array2);
            break;
            case 29: output = fun45(array1, array2);
            break;
            case 30: output = fun50(array1, array2);
            break;
            case 31: output = fun51(array1, array2);
            break;
            case 32: output = fun52(array1, array2);
            break;
            case 33: output = fun53(array1, array2);
            break;
            case 34: output = fun54(array1, array2);
            break;
            case 35: output = fun55(array1, array2);
            break;
            default: output = fun55(array1, array2);
            break;
        }
        return output;
    }
    #pragma warning disable 414
        private readonly string TwitchHelpMessage = @"Use !{0} q (01234) (12345) to query 01234 and 12345 in that order. Use !{0} s 1234512345 to submit 1234512345. ";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand (string Command){
        Command = Command.Trim().ToUpper();
        yield return null;
        string[] Commands = Command.Split(' ');
        if ((!"QS".Contains(Commands[0][0]) || Commands[0].Length != 1) && (Commands[0] != "QUERY") && (Commands[0] != "SUBMIT")){
            yield return "sendtochaterror Invalid command. The first statement must be either Query or Submit. ";
            yield break;
        } else if ((("S".Contains(Commands[0][0])||Commands[0] == "SUBMIT")&& Commands.Length != 2) || (("Q".Contains(Commands[0][0]) || Commands[0] == "QUERY") && Commands.Length !=3)){
            yield return "sendtochaterror Invalid Command. A submit command must have 1 number, and a query command must have 2 numbers";
            yield break;
        }
        for(int i = 1; i < Commands.Length; i++){
            for(int j = 0; j < Commands[i].Length; j++){
                if(!"012345".Contains(Commands[i][j])){
                    yield return "sendtochaterror Invalid Command. Numbers can only contain the characters 0-5";
                    yield break;
                }
            }
        }
        if(Commands[0] == "S" || Commands[0] == "SUBMIT"){
            buttons[7].OnInteract();
            yield return new WaitForSeconds(.1f);
            for(int i = 0; i<Commands[1].Length; i++){
                buttons[int.Parse(Commands[1][i].ToString())].OnInteract();
                yield return new WaitForSeconds(.1f);
            }
            buttons[7].OnInteract();
            yield break;
        }
        if(Commands[0] == "Q" || Commands[0] == "QUERY"){
            for(int i = 0; i<Commands[1].Length; i++){
                buttons[int.Parse(Commands[1][i].ToString())].OnInteract();
                yield return new WaitForSeconds(.1f);
            }
            buttons[8].OnInteract();
            for(int i = 0; i<Commands[2].Length; i++){
                buttons[int.Parse(Commands[2][i].ToString())].OnInteract();
                yield return new WaitForSeconds(.1f);
            }
            buttons[6].OnInteract();
        }
    }
    IEnumerator TwitchHandleForcedSolve () { //Note: The way that this solver works is that it disables the restrictions to submit. 
        yield return null;
        reston = false;
        buttons[7].OnInteract();
        yield return new WaitForSeconds(.1f);
        int[] answer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        answer = encode((decode(funSorting(current, ans1, ans2)))+36*meta+current);
        for(int i = (answer.Length-1); i >= 0; i--){
            buttons[answer[i]].OnInteract();
            yield return new WaitForSeconds(.1f);
        }
        buttons[7].OnInteract();
    }
}
