<?php

namespace App\Http\Controllers;
use Hash;
use DB;
use Auth;
use Session;
use Response;
use Input;
use Mail;
use App\Exceptions\SymfonyDisplayer;
use App\User;
use App\TakeOrder;
use App\Produk;
use App\Role;
use App\Kota;
use App\Konfigurasi;
use App\Counter;
use App\Outlet;
use App\Distributor;
use App\Tipe;
use App\TipePhoto;
use App\Area;
use App\Logging;
use App\Competitor;
use App\VisitPlan;
use App\PhotoActivity;
use App\Http\Controllers\Controller;
use App\Http\Requests\UserRequest;
use Illuminate\Http\Request;

class WSDesktop extends Controller
{
    
    /**
     * Store a newly created resource in storage.
     *
     * @return Response
     */
    public function getAllData()
    {
    	$area = Area::all();
        $competitor = Competitor::all();
        $distributor = Distributor::all();
        $konfigurasi = Konfigurasi::all();
        $kota = Kota::all();
        $logging = Logging::all();
        $outlet = Outlet::all();
        $photo = PhotoActivity::all();
        $produk = Produk::all();
        $takeorder = TakeOrder::all();
        $tipe = Tipe::all();
        $tipePhoto = TipePhoto::all();
        $user = User::all();
        $visitplan = VisitPlan::all();
        $dataUser = array("area"=>$area,"competitor"=>$competitor,"distributor"=>$distributor,"konfigurasi"=>$konfigurasi,"kota"=>$kota,"logging"=>$logging,"outlet"=>$outlet,"photo"=>$photo,"produk"=>$produk,"takeorder"=>$takeorder,"tipe"=>$tipe,"tipe_photo"=>$tipePhoto,"user"=>$user,"visitplan"=>$visitplan);
        return Response::json($dataUser,200);
    }
    public function insertOutlet()
    {
    	$id = -1;
        $data=new Outlet;
        $kota = Kota::where("id",Input::get('kd_kota'))->first();
        if(!Input::has('nm_outlet'))
        {
            $out['status'] = "no data sent";
            return Response::json($out,500);
        }
        $konfig = Konfigurasi::first();
        $data->kd_dist=Input::get('kd_dist');
        $data->kd_kota=Input::get('kd_kota');
        $data->kd_area=$kota->kd_area;
        $data->kd_user=Input::get('kd_user');
        $data->nm_outlet=Input::get('nm_outlet');
        $data->almt_outlet=Input::get('almt_outlet');
        $data->kd_tipe=Input::get('kd_tipe');
        $data->rank_outlet=Input::get('rank_outlet');
        $data->kodepos=Input::get('telp_outlet');
        $data->reg_status=Input::get('reg_status');
        $data->latitude=Input::get('latitude');
        $data->longitude=Input::get('longitude');
        $data->nm_pic=Input::get('nama_pic');
        $data->tlp_pic=Input::get('tlp_pic');
        $data->toleransi_long=$konfig->toleransi_max;
        $success = $data->save();
        $path = 'image_upload/outlet/';
        $base =Input::get('foto');
        $binary = base64_decode($base);
        header('Content-Type: bitmap; charset=utf-8');

        $f = finfo_open();
        $mime_type = finfo_buffer($f, $binary, FILEINFO_MIME_TYPE);
        $mime_type = str_ireplace('image/', '', $mime_type);

        $filename =  strval($data->kd_outlet).date('_YmdHis'). '.' . $mime_type;
        $file = fopen($path . $filename, 'wb');
        if (fwrite($file, $binary)) {
            $data->update(array('foto_outlet' => $filename));
            fclose($file);
        }
        $logging = new Logging;
        $logging->kd_user = Input::get("kd_user");
        $logging->description = "Register outlet ".Input::get("nm_outlet");
        $logging->log_time = Input::get('tgl_upload');
        $logging->detail_akses = "desktop";
        $logging->save();
        $out['status'] = "success";
        $out['id'] = $data->kd_outlet;
        return Response::json($out,201); 
    }
}