package hr.com.mroBot;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.Set;
import java.util.UUID;

import android.support.v7.app.ActionBarActivity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnTouchListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity extends ActionBarActivity {

	EditText unos;
	TextView poruka;
	BluetoothAdapter mBluetoothAdapter;
	BluetoothSocket mmSocket;
	BluetoothDevice mmDevice;
    OutputStream mmOutputStream;
    InputStream mmInputStream;
    Thread workerThread;
    Thread slanje;
    byte[] readBuffer;
    int readBufferPosition;
    int counter;
    volatile boolean stopWorker;
    volatile boolean salji;
	
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        
        Button btnSpoji = (Button)findViewById(R.id.btnSpoji);
        Button btnOdspoji = (Button)findViewById(R.id.btnOdspoji);
        Button btnNaprijed = (Button)findViewById(R.id.btnNaprijed);
        Button btnNazad = (Button)findViewById(R.id.btnNazad);
        Button btnLijevo = (Button)findViewById(R.id.btnLijevo);
        Button btnDesno = (Button)findViewById(R.id.btnDesno);
        
        btnSpoji.setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v)
            {
                try 
                {
                    findBT();
                    openBT();
                }
                catch (IOException ex) { }
            }
        });

        btnNaprijed.setOnTouchListener(new OnTouchListener(){
			public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
			    case MotionEvent.ACTION_DOWN:
			        try {
						sendData("n");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    case MotionEvent.ACTION_UP:
			        try {
						sendData("s");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    default:
			        break;
			    }
			    return true;
			}

			private void prekiniSlanje() {
				salji = true;
				
			}
		});
        
        btnNazad.setOnTouchListener(new OnTouchListener(){
        	public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
			    case MotionEvent.ACTION_DOWN:
			        try {
						sendData("b");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    case MotionEvent.ACTION_UP:
			        try {
						sendData("s");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    default:
			        break;
			    }
			    return true;
			}

			private void prekiniSlanje() {
				salji = true;
				
			}
		});
        
        btnLijevo.setOnTouchListener(new OnTouchListener(){
        	public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
			    case MotionEvent.ACTION_DOWN:
			        try {
						sendData("l");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    case MotionEvent.ACTION_UP:
			        try {
						sendData("s");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    default:
			        break;
			    }
			    return true;
			}

			private void prekiniSlanje() {
				salji = true;
				
			}
		});
        
        btnDesno.setOnTouchListener(new OnTouchListener(){
        	public boolean onTouch(View v, MotionEvent event) {
				switch (event.getAction()) {
			    case MotionEvent.ACTION_DOWN:
			        try {
						sendData("d");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    case MotionEvent.ACTION_UP:
			        try {
						sendData("s");
					} catch (IOException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
			        break;
			    default:
			        break;
			    }
			    return true;
			}

			private void prekiniSlanje() {
				salji = true;
				
			}
		});
        
        btnOdspoji.setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v)
            {
                try 
                {
                    closeBT();
                }
                catch (IOException ex) { }
            }
        });
    }

    void findBT()
    {
        mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        if(mBluetoothAdapter == null)
        {
            Toast.makeText(this,"No bluetooth adapter available", Toast.LENGTH_SHORT).show();
        }
        
        if(!mBluetoothAdapter.isEnabled())
        {
            Intent enableBluetooth = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableBluetooth, 0);
        }
        
        Set<BluetoothDevice> pairedDevices = mBluetoothAdapter.getBondedDevices();
        if(pairedDevices.size() > 0)
        {
            for(BluetoothDevice device : pairedDevices)
            {
                if(device.getName().equals("HC-05")) 
                {
                    mmDevice = device;
                    break;
                }
            }
        }
        //Toast.makeText(this,mmDevice.getName(), Toast.LENGTH_SHORT).show();
        Toast.makeText(this,"Naden uredaj", Toast.LENGTH_SHORT).show();
    }

    void openBT() throws IOException
    {
    	//Toast.makeText(this,"TEST", Toast.LENGTH_SHORT).show();
        UUID uuid = UUID.fromString("00001101-0000-1000-8000-00805f9b34fb");
        mmSocket = mmDevice.createRfcommSocketToServiceRecord(uuid);      
        mmSocket.connect();
        mmOutputStream = mmSocket.getOutputStream();
        mmInputStream = mmSocket.getInputStream();
        
        beginListenForData();
        
        Toast.makeText(this,"Veza otvorena", Toast.LENGTH_SHORT).show();
    }
    
    void beginListenForData()
    {
        final Handler handler = new Handler(); 
        final byte delimiter = 10; 
        
        stopWorker = false;
        readBufferPosition = 0;
        readBuffer = new byte[1024];
        workerThread = new Thread(new Runnable()
        {
            public void run()
            {                
               while(!Thread.currentThread().isInterrupted() && !stopWorker)
               {
                    try 
                    {
                        int bytesAvailable = mmInputStream.available();                        
                        if(bytesAvailable > 0)
                        {
                            byte[] packetBytes = new byte[bytesAvailable];
                            mmInputStream.read(packetBytes);
                            for(int i=0;i<bytesAvailable;i++)
                            {
                                byte b = packetBytes[i];
                                if(b == delimiter)
                                {
                                    byte[] encodedBytes = new byte[readBufferPosition];
                                    System.arraycopy(readBuffer, 0, encodedBytes, 0, encodedBytes.length);
                                    final String data = new String(encodedBytes, "US-ASCII");
                                    readBufferPosition = 0;
                                    
                                    handler.post(new Runnable()
                                    {
                                        public void run()
                                        {
                                        	poruka = (TextView)findViewById(R.id.textView1);
                                            poruka.setText(data);
                                        }
                                    });
                                }
                                else
                                {
                                    readBuffer[readBufferPosition++] = b;
                                }
                            }
                        }
                    } 
                    catch (IOException ex) 
                    {
                        stopWorker = true;
                    }
               }
            }
        });

        workerThread.start();
    }
    
    private void slanje_poruke (final String msg)
    {
    	salji = false;
        slanje = new Thread(new Runnable() {

			@Override
			public void run() {
				//while(!Thread.currentThread().isInterrupted() && !salji)
				//{
		        	try {
						mmOutputStream.write(msg.getBytes(),0,msg.length());
					} catch (IOException ex) {
						salji = true;
					}
				//}
			}
        });
        slanje.start();
    }
    
    void sendData(String s) throws IOException
    {
        slanje_poruke(s);
        //Toast.makeText(this,"Podaci su poslani", Toast.LENGTH_SHORT).show();
    }
    
    void closeBT() throws IOException
    {
        stopWorker = true;
        mmOutputStream.close();
        //mmInputStream.close();
        mmSocket.close();
        Toast.makeText(this,"Veza je zatvorena", Toast.LENGTH_SHORT).show();
    }
    
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        if (id == R.id.action_settings) {
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
}

