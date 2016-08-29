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
}