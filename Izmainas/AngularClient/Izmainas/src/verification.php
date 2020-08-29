<?php
  if(isset($_GET['vkey']) && isset($_GET['email'])){
    $vkey = $_GET['vkey'];
    $email = $_GET['email'];

    echo "the email is: " + $email + "; the key is: " + $vkey;

    /*
    $url = 'https://localhost:5001/api/v1/tempemailmodels/verify';
    $data = [
      'email' => $email,
      'vkey' => $vkey
    ];

    $curl = curl_init($url);
    curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($curl, CURLOPT_POST, true);
    curl_setopt($curl, CURLOPT_POSTFIELDS,  json_encode($data));

    curl_setopt($curl, CURLOPT_HTTPHEADER, [
      'Content-Type: application/json'
    ]);

    $response = curl_exec($curl);
    curl_close($curl);

    echo $response . PHP_EOL;
    */
  }
?>
