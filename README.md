# Proof of Concept: Constants Editor for Unity Editor
This is a proof of concept made for managing constants easily in the Unity Editor! <br>

<h2> Goals </h2>
<p>
	This POC had one main goals: <br>
	<b> 1: Save constants like variables without needing to change a single line of code. </b> <br>
</p>

<h2> Problems </h2>
<h4> <p> Problem 1: The editor itself asynchronously lobby </p> </h4>
<p>
	My idea is to create a editor window that selects a file and 1: returns all the constants saved within
  that file and 2: creates a field that makes possible to save new constants to that file. The file itself
  is a scriptable object that, when created, is saved in the assets path or a subfolder within it.
</p>

<h2> Achieved </h2>
<p>
  Until now, I only achieved the creating of the editor window and a tabs divisioning system to manage multiple
  files at the same time.
</p>
