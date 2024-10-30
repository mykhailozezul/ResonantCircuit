<h2>Circuit Calculator</h2>
<p>This personal project is designed for exploring, analyzing, and enhancing understanding of RLC filters, resonant circuits and recently added 555 timer.</p>
<p>.NET 8-compatible classes for calculating parameters of:</p>
<ul>
  <li>Series RLC resonant circuit</li>
  <li>Parallel RLC resonant circuit</li>
  <li>555 Timer</li>
</ul>

<h2>There are three main parts</h2>
<h3><bold>Units</bold></h3>

<p>The Unit class functions as a value container. To create a Unit and assign values, use the following syntax:</p>

```C#
Unit L = new Unit(); // Create a unit
L.ParametricValue = "2u"; // Assign a parametric value
L.SIValue = 0.1; // Assign a SI value
```

<p>Parametric value postfixes are defined as follows:</p>

<ul>
  <li>p = -12</li>
  <li>n = -9</li>
  <li>u = -6</li>
  <li>m = -3</li>
  <li>none = 0</li>
  <li>k = 3</li>
  <li>meg = 6</li>
  <li>g = 9</li>
  <li>t = 12</li>
</ul>

<h3><bold>Circuits</bold></h3>

<p>Currently, there are three types of circuits:</p>
<ul>
  <li>
  series and parallel RLC circuits and 
  </li>
  <li>555 Timer in astable mode.
  </li>
</ul>
<p>To create instances of these circuits, use the following constructors:</p>

```C#
var filterSeries = new LCSeries(R, L, C); // Create a series RLC circuit
var filterParallel = new LCParallel(R, L, C); // Create a parallel RLC circuit
var timer = new Timer555(R1, R2, C); //Create 555 Timer
```

<h4><bold>Circuit Methods</bold></h4>
<h5><bold>Resonant Circuits</bold></h5>
<hr style="width: 150px;margin-left: 0;" />

<p>Each resonant circuit type offers four public methods to explore various characteristics and responses:</p>

<ol>
  <li><b>F_LC</b> - Calculates the resonant frequency based on values of L (inductance) and C (capacitance).</li>
  <li><b>L_FC</b> - Determines the value of L required for a desired frequency and given C.</li>
  <li><b>C_FL</b> - Computes the value of C needed for a desired frequency and given L.</li>
  <li><b>Input_F</b> - Applies a specific frequency to the circuit, allowing observation of how the resonant circuit responds to different frequencies.</li>
</ol>

<p>Here's how you can utilize these methods:</p>

```C#
var plc = new LCParallel(R, L, C); // Create an instance of a parallel RLC circuit
LCParallel.F_LC(plc); // Updates the circuit instance with new frequency based on L and C inputs
```

<h4>555 Timer</h4>
<hr style="width: 150px; margin-left: 0;" />

<p>Timer 555 offers one method for calculating series of parameters which include: frequency, high time, low time, period, and duty cycle in Astable mode</p>

<ol><li><b>ASTABLE_MODE</b></li></ol>

<p>Here is how you can utilize the method:</p>

```C#
Timer555.ASTABLE_MODE(timer);
```

<h3><bold>Sweeping values</bold></h3>

<p>The Sweep class enables setting any circuit parameter within a specified range and adjusting it at a defined rate, allowing us to observe how the circuit reacts to changes. For instance, you can apply a frequency sweep from 1 mHz to 100 mHz with a step of 5 mHz to an RLC circuit. This is particularly useful for analyzing how the circuit filters different frequencies.</p>

<p>In the following code we sweep through 2 parameters R1 and R2 and recalculate the 555 Timer output on each iteration</p>

```C#
//create circuit input params
Unit R1 = new Unit();
Unit R2 = new Unit();
Unit C = new Unit();

//assign values to each param
R1.ParametricValue = "0";
R2.ParametricValue = "3";
C.ParametricValue = "1u";

//create 555 Timer circuit
var timer = new Timer555(R1, R2, C);

//create list of parameters which we want to sweep
var list = new List<SweepContainer>() {

    /*
    SweepContainer - If we want to sweep values for R1 parameter between 0 Ohm and 3O hm with step 0.3 Ohm inside the Timer555, we pass its reference to the first parameter of SweepContainer
    */

    //first sweep parameter
    new SweepContainer(timer.R1, //pass reference to R1
      new Unit() {
        ParametricValue="0" //assign start value of 0 Ohm
      },
      new Unit() {
        ParametricValue="3" //assign end value of 3 Ohm
      },
      new Unit() {
        ParametricValue="0.3" //sweeping step of 0.3 Ohm
      }
    ),

    //second sweep parameter
    new SweepContainer(timer.R2, //pass reference to R2
      new Unit() {
        ParametricValue="10" //assign start value of 10 Ohm
      },
      new Unit() {
        ParametricValue="1" //assign end value of 1 Ohm
      },
      new Unit() {
        ParametricValue="1" //assign step of 1 Ohm
      }
    )

};

//perform sweeping for R1 and R2
string output = UnitSweep.Sweep(timer, list, Timer555.ASTABLE_MODE, SweepModesEnum.FollowEndVal);

//output is in CSV format for easy export to Excel and python
```

<p>Resonant Circuit results include:</p>
<ul>
  <li>L - Inductance</li>
  <li>C - Capacitance</li>
  <li>F - Frequency</li>
  <li>R - Resistance</li>
  <li>XL - Inductor Reactance</li>
  <li>XC - Capacitor Reactance</li>
  <li>Q - Quality factor</li>
  <li>BW - Circuit Bandwidth</li>
  <li>BW_FL - Bandwidth lowest limit</li>
  <li>BW_FH - Bandwidth highest limit</li>
  <li>Z - Impendance</li>
  <li>WL - Wave length</li>
</ul>

<p>Timer 555 results include</p>
<ul>
  <li>F - Frequency</li>
  <li>R1 - Resistance 1</li>
  <li>R2 - Resistance 2</li>
  <li>C - Capacitance</li>
  <li>TH - Time High (seconds)</li>
  <li>TL - Time Low (seconds)</li>
  <li>TX - Time Period (seconds)</li>
  <li>DC - Duty Cycle (%)</li>
</ul>

<p>Console output</p>
<img src="https://github.com/mykhailozezul/ResonantCircuit/assets/110465477/e1351846-2eb5-479a-85cc-a1dc7e8f3f4c">

<p>Copied to Excel resonant circuit analysis</p>
<img src="https://github.com/mykhailozezul/ResonantCircuit/assets/110465477/c1a073ac-f658-4f98-8301-bd22788ef15d" >
