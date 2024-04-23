<h3>Resonant Circuit Calculator</h3>
<p>.NET 8-compatible classes for calculating parameters of parallel and series RLC resonant circuits. This personal project is designed for exploring, analyzing, and enhancing understanding of RLC filters and resonant circuits.</p>
<h4>There are three main parts:</h4>
<h4>Units</h4>

<p>The Unit class functions as a value container. To create a Unit and assign values, use the following syntax:</p>

<code>
Unit L = new Unit();  // Create a unit
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

<h4>Circuits</h4>

<p>Currently, there are two types of RLC circuits: series and parallel. To create instances of these circuits, use the following code:</p>

<code>
var filterSeries = new LCSeries(R, L, C);  // Create a series RLC circuit
var filterParallel = new LCParallel(R, L, C);  // Create a parallel RLC circuit
</code>

<p>Each constructor requires three parameters: resistance (R), inductance (L), and capacitance (C).</p>

<h5>Circuit Methods</h5>

<p>Each circuit type offers four public methods to explore various characteristics and responses:</p>

<ol>
  <li>F_LC - Calculates the resonant frequency based on values of L (inductance) and C (capacitance).</li>
  <li>L_FC - Determines the value of L required for a desired frequency and given C.</li>
  <li>C_FL - Computes the value of C needed for a desired frequency and given L.</li>
  <li>Input_F - Applies a specific frequency to the circuit, allowing observation of how the resonant circuit responds to different frequencies.</li>
</ol>

<p>Here's how you can utilize these methods:</p>

<code>
var plc = new LCParallel(R, L, C); // Create an instance of a parallel RLC circuit

LCParallel.F_LC(plc); // Updates the circuit instance with new frequency based on L and C inputs
</code>
