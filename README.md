<h3>Resonant Circuit Calculator</h3>
<p>.NET 8-compatible classes for calculating parameters of parallel and series RLC resonant circuits. This personal project is designed for exploring, analyzing, and enhancing understanding of RLC filters and resonant circuits.</p>
<h5>There are three main parts:</h5>
<h5>Units</h5>

<p>The Unit class functions as a value container. To create a Unit and assign values, use the following syntax:</p>

<code>Unit L = new Unit();  // Create a unit
L.ParametricValue = "2u";  // Assign a parametric value
L.SIValue = 0.1;  // Assign an SI value</code>

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
