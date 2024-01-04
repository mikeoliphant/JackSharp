using Jack.NAudio;
using JackSharp;
using NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

System.Console.WriteLine("Recording");

using var client = new Processor("AudioTranscription", 2, 2, 0, 0, true);
client.Start();
Console.ReadKey();
using var audioIn = new AudioIn(client);
System.Console.WriteLine(audioIn.WaveFormat);
using var audioOut = new AudioOut(client);
using var stream = new MemoryStream();

audioIn.DataAvailable += (s,e) => {
    stream.Write(e.Buffer, 0, e.BytesRecorded);
};
audioIn.RecordingStopped += (s,e) => {
    Console.WriteLine("Recording Stopped");
    stream.Position = 0;
};
audioIn.StartRecording();
Thread.Sleep(TimeSpan.FromSeconds(5));
audioIn.StopRecording();
Thread.Sleep(TimeSpan.FromSeconds(1));

///////////////////////////////////////////////

System.Console.WriteLine("Playback");

var wavStream = new RawSourceWaveStream(stream, audioIn.WaveFormat);
var resampled = new WdlResamplingSampleProvider(wavStream.ToSampleProvider(), 16000);
audioOut.Init(resampled);
audioOut.Play();
Thread.Sleep(TimeSpan.FromSeconds(10));
audioOut.Stop();


