var ObjectSpawn:GameObject;
var SpawnRate:float;
var LifeTimeObject:float = 1;
var LimitObject:int = 3;
private var timetemp;
private var objcount:int;
var PositionRandomSize:Vector3;
var PositionOffset:Vector3;
function Start(){
	timetemp = Time.time;
}
function Update () {
	if(Time.time > timetemp + SpawnRate){
		if(ObjectSpawn){
			if(objcount < LimitObject){
				var positionoffset:Vector3 = new Vector3(Random.Range(0,PositionRandomSize.x),Random.Range(0,PositionRandomSize.y),Random.Range(0,PositionRandomSize.z));
				var obj = GameObject.Instantiate(ObjectSpawn,this.transform.position+positionoffset+PositionOffset,this.transform.rotation);
				objcount++;
				Destroy(obj,LifeTimeObject);
			}
		}
		timetemp = Time.time;
	}
}