
var minSpeed:float=0.7;
var maxSpeed:float=1.5;

function Start () {
    (GetComponent.<Animation>() as Animation)[(GetComponent.<Animation>() as Animation).clip.name].speed = Random.Range(minSpeed, maxSpeed);
}