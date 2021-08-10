var l1 = 100;
var l2 = 100;
var m1 = 20;
var m2 = 20;
var v1 = 0.01
var v2 = 3.14;
var v1_vel = 0;
var v2_vel = 0;
var g = 0.5;
var h = 0.5;

function setup() {
  createCanvas(450, 400);
}

function draw() {
  // ligninger fra: https://myphysicslab.com/pendulum/double-pendulum-en.html
  // theta' = a1_vel
  // theta'' = a1_acc
  
  // Pendul 1
  var tlr1 = -g * (2 * m1 + m2) * sin(v1);
  var tlr2 = -m2 * g * sin(v1 - 2 * v2);
  var tlr3 = -2 * sin(v1-v2) * m2;
  var tlr4 = v2_vel * v2_vel * l2 + v1_vel * v1_vel * l1 * cos(v1-v2);
  var nvn =  l1 * (2 * m1 + m2 - m2 * cos(2 * v1 - 2 * v2));
  
  var v1_acc = (tlr1 + tlr2 + tlr3 * tlr4) / nvn;
  
  // Pendul 2
  tlr1 = 2 * sin(v1-v2);
  tlr2 = (v1_vel * v1_vel * l1 * (m1 + m2));
  tlr3 = g * (m1 + m2) * cos(v1);
  tlr4 = v2_vel * v2_vel * l2 * m2 * cos(v1 - v2);
  
  var v2_acc = (tlr1 * (tlr2 + tlr3 + tlr4)) / nvn;
  
  // Giver baggrunden hvid farve og linjerne tydligere
  background(255);
  stroke(0);
  strokeWeight(2);
  
  // Sætter positionen af pendulet
  translate(width/2, height/5);
  
  // Beregning af koordniator til optegning af pendul
  var x1 = l1 * sin(v1);
  var y1 = l1 * cos(v1);
  var x2 = x1 + l2 * sin(v2);
  var y2 = y1 + l2 * cos(v2);
  
  // Optegning af pendul 1
  line(0, 0, x1, y1);
  fill(0);
  ellipse(x1, y1, m1, m1);
  
  // Optegning af pendul 2
  line(x1, y1, x2, y2);
  fill(0);
  ellipse(x2, y2, m2, m2);
  
  // Hastigheden er ændringen i accelerationen
  v1_vel += v1_acc * h;
  v2_vel += v2_acc * h;
  // Vinklen er ændring i hastigheden 
  v1 += v1_vel * h;
  v2 += v2_vel * h; 
}