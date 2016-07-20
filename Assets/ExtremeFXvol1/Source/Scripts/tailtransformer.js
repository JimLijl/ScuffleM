private var target:Vector3;
//var DirectionRandomMax:Vector3;
//var DirectionRandomMin:Vector3;
//var Skilltar:GameObject;
var Speed:float = 1;
private var timetemp:float;
var redirectRate:float = 0.5f;
function Start () {
}

function Update () {
	
	if(Time.time >= timetemp+redirectRate){
		//target = new Vector3(Random.Range(DirectionRandomMin.x,DirectionRandomMax.x),Random.Range(DirectionRandomMin.y,DirectionRandomMax.y),Random.Range(DirectionRandomMin.z,DirectionRandomMax.z));
		target = new Vector3(transform.position.x,transform.position.y,transform.position.z+100);
		timetemp = Time.time;
    } 
	var targetRotation = transform.rotation;
	//var targetRotation = transform.rotation;
    var str = Mathf.Min (10 * Time.deltaTime, 1);
    transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, str);
    transform.position += transform.forward*Speed* Time.deltaTime;
}