<h3>Resonant Circuit Calculator</h3>
<p>.NET 8-compatible classes for calculating parameters of parallel and series RLC resonant circuits. This personal project is designed for exploring, analyzing, and enhancing understanding of RLC filters and resonant circuits.</p>
<h4>There are three main parts:</h4>
<h3><bold>Units</bold></h3>

<p>The Unit class functions as a value container. To create a Unit and assign values, use the following syntax:</p>

<code>Unit L = new Unit();  // Create a unit
L.ParametricValue = "2u";  // Assign a parametric value
L.SIValue = 0.1;  // Assign an SI value
</code>

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

<p>Currently, there are three types of RLC circuits: series and parallel. To create instances of these circuits, use the following code:</p>

<code>var filterSeries = new LCSeries(R, L, C);  // Create a series RLC circuit
var filterParallel = new LCParallel(R, L, C);  // Create a parallel RLC circuit
var timer = new Timer555(R1, R2, C);
</code>

<p>Each resonant circuit constructor requires three parameters: resistance (R), inductance (L), and capacitance (C).</p>
<p>Timer 555 constructor requires three parameters as well: resistance (R1), resistance (R2), and capacitance (C)</p>

<h5><bold>Circuit Methods</bold></h5>

<p>Each resonant circuit type offers four public methods to explore various characteristics and responses:</p>

<ol>
  <li>F_LC - Calculates the resonant frequency based on values of L (inductance) and C (capacitance).</li>
  <li>L_FC - Determines the value of L required for a desired frequency and given C.</li>
  <li>C_FL - Computes the value of C needed for a desired frequency and given L.</li>
  <li>Input_F - Applies a specific frequency to the circuit, allowing observation of how the resonant circuit responds to different frequencies.</li>
</ol>

<p>Here's how you can utilize these methods:</p>

<code>var plc = new LCParallel(R, L, C); // Create an instance of a parallel RLC circuit
LCParallel.F_LC(plc); // Updates the circuit instance with new frequency based on L and C inputs
</code>

<p>Timer 555 offers one method for calculating frequency, high time, low time, period, and duty cycle in Astable mode</p>

<code>Timer555.ASTABLE_MODE</code>

<h3><bold>Sweeping values</bold></h3>

<p>The Sweep class enables the application of an array of values to a circuit to observe how the circuit reacts to changes. For instance, you can apply a frequency sweep from 1 mHz to 100 mHz with a step of 5 mHz to an RLC circuit. This is particularly useful for analyzing how the circuit filters different frequencies.</p>

<p>To use this functionality, first create an instance of the UnitSweep class with start value, stop value, and step:</p>

<code>var sweepSettings = new UnitSweep(
    new Unit() { ParametricValue = "5000" },  // Start value
    new Unit() { ParametricValue = "20000" }, // Stop value
    new Unit() { ParametricValue = "100" }    // Step
);</code>

<p>Next, apply these settings to the circuit using the Sweep method:</p>

<code>UnitSweep.Sweep<LCParallel>(
    sweepSettings, 
    circuitInstance, 
    circuitInstance.F, 
    LCParallel.Input_F
);</code>
<p>First parameter - sweep settings, second - instance of the LC circuit, third - the circuit's unit to be swept, fourth - method executed with each sweep value change</p>

<p>The results of the sweep are stored within the UnitSweep instance in the OutputResult property. Each sweep operation maintains its own results:</p>

<code>Console.WriteLine(sweepSettings.OutputResult); // Output sweep result to the console</code>

<p>The result of the sweep is output in CSV format, allowing it to be saved to a CSV file for further processing with Excel tools and graphs. This method provides a comprehensive and interactive way to study circuit behavior under various conditions.</p>

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

<p>Copied to Excel</p>
<img src="https://github.com/mykhailozezul/ResonantCircuit/assets/110465477/c1a073ac-f658-4f98-8301-bd22788ef15d" >

